using System;
using HtmlAgilityPack;
using ParseZakupki.Parser.Common;

namespace ParseZakupki.Parser.OTCParser.NodeParser
{
    public class OtcCostParser : INodeParser
    {
        public string Parse(HtmlNode node)
        {
            try
            {
                var cost = node
                    .SelectSingleNode(".//div[@class='result_item__price']/text()")
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
