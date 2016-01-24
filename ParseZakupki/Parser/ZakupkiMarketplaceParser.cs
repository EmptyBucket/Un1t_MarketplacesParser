using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace ParseZakupki.Parser
{
    public class ZakupkiMarketplaceParser : IMarketplaceParser
    {
        private readonly INodeContestParser mNodeContestParser;

        private static IReadOnlyCollection<HtmlNode> GetAllContestNodes(HtmlDocument doc) =>
            doc.DocumentNode.SelectNodes(".//div[@class='registerBox registerBoxBank margBtm20']").ToArray();

        public IReadOnlyCollection<PurchaseInformation> Parse(string docTxt)
        {
            var docHtml = new HtmlDocument();
            docHtml.LoadHtml(docTxt);
            var result = GetAllContestNodes(docHtml)
                .Select(node => mNodeContestParser.Parse(node))
                .ToArray();
            return result;
        }

        public ZakupkiMarketplaceParser(INodeContestParser contestNodeParser)
        {
            mNodeContestParser = contestNodeParser;
        }
    }
}
