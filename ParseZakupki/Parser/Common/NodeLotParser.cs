using System;
using HtmlAgilityPack;

namespace ParseZakupki.Parser
{
    public abstract class NodeLotParser : INodeLotParser
    {
        protected readonly INodeParser mDateCreatedParser;
        protected readonly INodeParser mCostParser;
        protected readonly INodeParser mCustomerParser;
        protected readonly INodeParser mDescParser;
        protected readonly INodeParser mIdParser;
        protected readonly IClient mClient;
        protected readonly Uri mDomain;
        protected readonly INodeParser mDateFillingParser;
        protected readonly INodeParser mSourceLinkParser;
        protected readonly INodeParser mCodeParser;

        public abstract PurchaseInformation Parse(HtmlNode node);

        public NodeLotParser(Uri domain, IClient client, INodeParser dateCreatedParser, INodeParser costParser, INodeParser customerParser, INodeParser descParser, INodeParser idParser, INodeParser dateFiilingParser, INodeParser codeParser, INodeParser sourceLinkParser)
        {
            mSourceLinkParser = sourceLinkParser;
            mCodeParser = codeParser;
            mDateFillingParser = dateFiilingParser;
            mDomain = domain;
            mClient = client;
            mDateCreatedParser = dateCreatedParser;
            mCostParser = costParser;
            mCustomerParser = customerParser;
            mDescParser = descParser;
            mIdParser = idParser;
        }
    }
}
