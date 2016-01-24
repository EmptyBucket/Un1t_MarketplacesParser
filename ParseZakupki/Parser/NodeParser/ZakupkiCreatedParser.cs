using HtmlAgilityPack;

namespace ParseZakupki.Parser
{
    public class ZakupkiCreatedParser : INodeParser
    {
        public string Parse(HtmlNode node)
        {
            var createdNode = node
                .SelectSingleNode(".//td[@class='amountTenderTd']/ul/li[1]/text()");
            var created = createdNode
                .InnerHtml
                .Trim();
            return created;
        }
    }
}
