using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using MarketplaceLocalDB;

namespace ParseZakupki.Parser.Common
{
    public class MarketplaceParser : IMarketplaceParser
    {
        private readonly INodeLotParser _nodeLotParser;
        private readonly ILotSpliter _documentSpliter;

        public IReadOnlyCollection<Lot> Parse(HtmlDocument docHtml)
        {
            var result = _documentSpliter.DocumentSplit(docHtml)
                .Select(node => _nodeLotParser.Parse(node))
                .ToArray();
            return result;
        }

        public MarketplaceParser(INodeLotParser contestNodeParser, ILotSpliter documentSpliter)
        {
            _nodeLotParser = contestNodeParser;
            _documentSpliter = documentSpliter;
        }
    }
}
