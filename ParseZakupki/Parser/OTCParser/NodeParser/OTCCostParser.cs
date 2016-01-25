using HtmlAgilityPack;

namespace ParseZakupki.Parser.OTCParser.NodeParser
{
    public class OTCCostParser : INodeParser
    {
        public string Parse(HtmlNode node)
        {
            var cost = node
                .SelectSingleNode(".//div[@class='result_item__price']/text()")
                .InnerText
                .Trim();
            return cost;
        }
    }
}
