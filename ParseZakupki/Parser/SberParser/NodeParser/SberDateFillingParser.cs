using System;
using HtmlAgilityPack;
using ParseZakupki.Parser.Common;

namespace ParseZakupki.Parser.SberParser.NodeParser
{
    public class SberDateFillingParser : INodeParser
    {
        public string Parse(HtmlNode node)
        {
            try
            {
                var dateFillingStart = node
                .SelectSingleNode(".//td[@content='leaf:requestDateStr']/text()")
                .InnerText
                .Trim();
                return dateFillingStart;
            }
            catch (Exception)
            {
                return "None";
            }
        }
    }
}