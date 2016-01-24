using HtmlAgilityPack;

namespace ParseZakupki.Parser
{
    public class NodeContestParser : INodeContestParser
    {
        private readonly INodeParser mCreatedParser;
        private readonly INodeParser mCostParser;
        private readonly INodeParser mCustomerParser;
        private readonly INodeParser mUpdatedParser;
        private readonly INodeParser mDescParser;
        private readonly INodeParser mIdParser;

        public PurchaseInformation Parse(HtmlNode node)
        {
            var purchase = new PurchaseInformation()
            {
                Created = mCreatedParser.Parse(node),
                Cost = mCostParser.Parse(node),
                Customer = mCustomerParser.Parse(node),
                Updated = mUpdatedParser.Parse(node),
                Description = mDescParser.Parse(node),
                SiteId = mIdParser.Parse(node)
            };
            return purchase;
        }

        public NodeContestParser(INodeParser createdParser, INodeParser updatedParser, INodeParser costParser, INodeParser customerParser, INodeParser descParser, INodeParser idParser)
        {
            mCreatedParser = createdParser;
            mCostParser = costParser;
            mCustomerParser = customerParser;
            mUpdatedParser = updatedParser;
            mDescParser = descParser;
            mIdParser = idParser;
        }
    }
}
