using System;
using HtmlAgilityPack;
using ParseZakupki.Entity;

namespace ParseZakupki.Parser.Common
{
    public abstract class NodeLotParser : INodeLotParser
    {
        protected readonly INodeParser DateCreatedParser;
        protected readonly INodeParser CostParser;
        protected readonly INodeParser CustomerParser;
        protected readonly INodeParser DescParser;
        protected readonly INodeParser IdParser;
        protected readonly Uri Domain;
        protected readonly INodeParser DateFillingParser;
        protected readonly INodeParser SourceLinkParser;
        protected readonly INodeParser CodeParser;

        public abstract PurchaseInformation Parse(HtmlNode node);

        protected NodeLotParser(Uri domain, INodeParser dateCreatedParser, INodeParser costParser, INodeParser customerParser, INodeParser descParser, INodeParser idParser, INodeParser dateFillingParser, INodeParser codeParser, INodeParser sourceLinkParser)
        {
            SourceLinkParser = sourceLinkParser;
            CodeParser = codeParser;
            DateFillingParser = dateFillingParser;
            Domain = domain;
            DateCreatedParser = dateCreatedParser;
            CostParser = costParser;
            CustomerParser = customerParser;
            DescParser = descParser;
            IdParser = idParser;
        }
    }
}
