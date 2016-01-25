using HtmlAgilityPack;

namespace ParseZakupki.Parser
{
    public class ZakupkiSourceLinkParser : INodeParser
    {
        public string Parse(HtmlNode node)
        {
            var link = node
                .SelectSingleNode(".//td[@class='descriptTenderTd']/dl/dt/a")
                .Attributes["href"]
                .Value;
            return link;
        }
    }
}
