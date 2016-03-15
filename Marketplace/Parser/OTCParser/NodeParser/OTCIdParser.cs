using System;
using HtmlAgilityPack;
using ParseZakupki.Parser.Common;

namespace ParseZakupki.Parser.OTCParser.NodeParser
{
    public class OtcIdParser : INodeParser
    {
        public string Parse(HtmlNode node)
        {
            try
            {
                var id = node
                    .SelectSingleNode(".//span[@class='tender-numbers']/a/text()")
                    .InnerText
                    .Trim();
                return id;
            }
            catch (Exception)
            {
                return "None";
            }
        }
    }
}
