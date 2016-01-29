using System;
using System.Web;
using HtmlAgilityPack;
using ParseZakupki.Parser.Common;

namespace ParseZakupki.Parser.ZakupkiParser.NodeParser
{
    public class ZakupkiDescriptionParser : INodeParser
    {
        public string Parse(HtmlNode node)
        {
            try
            {
                var desc = node
                    .SelectSingleNode(".//td[@class='descriptTenderTd']/dl/dd[2]/text()")
                    .InnerText
                    .Trim();
                var decodedDesc = HttpUtility.HtmlDecode(desc);
                return decodedDesc;
            }
            catch (Exception)
            {
                return "None";
            }
        }
    }
}