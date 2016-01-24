using HtmlAgilityPack;

namespace ParseZakupki.Parser
{
    public class ZakupkiUpdatedParser : INodeParser
    {
        public string Parse(HtmlNode node)
        {
            var createdNode = node
                .SelectSingleNode(".//td[@class='amountTenderTd']/ul/li[2]/text()");
            var created = createdNode
                .InnerHtml
                .Trim();
            return created;
        }
    }
}