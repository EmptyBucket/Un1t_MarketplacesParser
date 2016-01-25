using HtmlAgilityPack;

namespace ParseZakupki.Parser.OTCParser.NodeParser
{
    public class OTCIdParser : INodeParser
    {
        public string Parse(HtmlNode node)
        {
            var id = node
                .SelectSingleNode(".//span[@class='tender-numbers']/a/text()")
                .InnerText
                .Trim();
            return id;
        }
    }
}
