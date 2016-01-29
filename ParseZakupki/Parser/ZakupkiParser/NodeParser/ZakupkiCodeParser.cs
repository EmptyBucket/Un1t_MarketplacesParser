using System;
using HtmlAgilityPack;
using ParseZakupki.Parser.Common;

namespace ParseZakupki.Parser.ZakupkiParser.NodeParser
{
    public class ZakupkiCodeParser : INodeParser
    {
        public string Parse(HtmlNode node)
        {
            try
            {
                var code = node
                    .SelectSingleNode(".//div[@class='addingTbl col6Tbl']//tr[@class='tdHead']/following-sibling::tr/tr/tr/td[2]/text()")
                    .InnerText
                    .Trim();
                return code;
            }
            catch (Exception)
            {
                return "None";
            }
        }
    }
}
