using System;
using HtmlAgilityPack;
using MarketplaceDB;
using ParseZakupki.Client;
using ParseZakupki.Entity;
using ParseZakupki.Parser.Common;

namespace ParseZakupki.Parser.OTCParser
{
    public class OtcNodeLotParser : NodeLotParser
    {
        private readonly IClient _client;

        public OtcNodeLotParser(Uri domain, IClient client, INodeParser dateCreatedParser, INodeParser costParser, INodeParser customerParser, INodeParser descParser, INodeParser idParser, INodeParser dateFillingParser, INodeParser codeParser, INodeParser sourceLinkParser) : base(domain, dateCreatedParser, costParser, customerParser, descParser, idParser, dateFillingParser, codeParser, sourceLinkParser)
        {
            _client = client;
        }

        public override Marketplace Parse(HtmlNode node)
        {
            var absoluteLink = SourceLinkParser.Parse(node);
            var lotPageHtml = _client.GetResult(new Uri(absoluteLink));
            var htmlDocLotPage = new HtmlDocument();
            htmlDocLotPage.LoadHtml(lotPageHtml);
            var nodeLotPage = htmlDocLotPage.DocumentNode;
            var purchase = new Marketplace
            {
                DateFilling = DateFillingParser.Parse(node),
                Code = CodeParser.Parse(nodeLotPage),
                SourceLink = absoluteLink,
                DateCreated = DateCreatedParser.Parse(nodeLotPage),
                Cost = CostParser.Parse(node),
                Customer = CustomerParser.Parse(node),
                Description = DescParser.Parse(node),
                SiteId = IdParser.Parse(node)
            };
            return purchase;
        }
    }
}
