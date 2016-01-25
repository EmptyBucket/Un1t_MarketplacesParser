using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace ParseZakupki.Parser
{
    public class MarketplaceParser : IMarketplaceParser
    {
        private readonly NodeLotParser mNodeLotParser;
        private readonly ILotsSpliter mDocumentSpliter;

        public IReadOnlyCollection<PurchaseInformation> Parse(HtmlDocument docHtml)
        {
            var result = mDocumentSpliter.DocumentSplit(docHtml)
                .Select(node => mNodeLotParser.Parse(node))
                .ToArray();
            return result;
        }

        public MarketplaceParser(NodeLotParser contestNodeParser, ILotsSpliter documentSpliter)
        {
            mNodeLotParser = contestNodeParser;
            mDocumentSpliter = documentSpliter;
        }
    }
}
