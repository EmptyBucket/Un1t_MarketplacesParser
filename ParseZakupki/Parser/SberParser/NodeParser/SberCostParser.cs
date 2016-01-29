using System;
using HtmlAgilityPack;
using ParseZakupki.Parser.Common;

namespace ParseZakupki.Parser.SberParser.NodeParser
{
    public class SberCostParser : INodeParser
    {
        public string Parse(HtmlNode node)
        {
            try
            {
                var cost = node
                    .SelectSingleNode(".//td[@content='leaf:purchAmount']/text()")
                    .InnerText
                    .Trim();
                return cost;
            }
            catch (Exception)
            {
                return "None";
            }
        }
    }
}