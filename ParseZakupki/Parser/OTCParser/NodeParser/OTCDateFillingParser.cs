using HtmlAgilityPack;

namespace ParseZakupki.Parser.OTCParser.NodeParser
{
    public class OTCDateFillingParser : INodeParser
    {
        public string Parse(HtmlNode node)
        {
            var dateFillingStart = node
                .SelectSingleNode(".//span[@class='result_item__worktime_date']/text()")
                .InnerText
                .Trim();
            var dateFillingEnd = node
                .SelectSingleNode(".//span[@class='result_item__worktime_date']/text()")
                .InnerText
                .Trim();
            return dateFillingStart + " - " + dateFillingEnd;
        }
    }
}
