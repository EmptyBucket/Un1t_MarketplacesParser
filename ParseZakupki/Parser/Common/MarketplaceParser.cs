using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using ParseZakupki.Entity;

namespace ParseZakupki.Parser.Common
{
    public class MarketplaceParser : IMarketplaceParser
    {
        private readonly INodeLotParser _nodeLotParser;
        private readonly ILotsSpliter _documentSpliter;

        public IReadOnlyCollection<PurchaseInformation> Parse(HtmlDocument docHtml)
        {
            var result = _documentSpliter.DocumentSplit(docHtml)
                .Select(node => _nodeLotParser.Parse(node))
                .ToArray();
            return result;
        }

        public MarketplaceParser(INodeLotParser contestNodeParser, ILotsSpliter documentSpliter)
        {
            _nodeLotParser = contestNodeParser;
            _documentSpliter = documentSpliter;
        }
    }
}
