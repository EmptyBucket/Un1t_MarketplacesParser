using HtmlAgilityPack;

namespace ParseZakupki.Parser.OTCParser.NodeParser
{
    public class OTCDescriptionParser : INodeParser
    {
        public string Parse(HtmlNode node)
        {
            var desc = node
                .SelectSingleNode(".//h3[@class='result_item__title']/a/text()")
                .InnerText
                .Trim();
            return desc;
        }
    }
}
