using System;
using HtmlAgilityPack;
using MarketplaceDB;
using ParseZakupki.Client;
using ParseZakupki.Entity;
using ParseZakupki.Parser.Common;

namespace ParseZakupki.Parser.SberParser
{
    public class SberNodeLotParser : NodeLotParser
    {
        private readonly IClient _client;

        public override Marketplace Parse(HtmlNode node)
        {
            var relativeLink = SourceLinkParser.Parse(node);
            var absoluteLink = new Uri(Domain, relativeLink);
            var lotPageHtml = _client.GetResult(absoluteLink);
            var htmlDocLotPage = new HtmlDocument();
            htmlDocLotPage.LoadHtml(lotPageHtml);
            var nodeLotPage = htmlDocLotPage.DocumentNode;
            var purchase = new Marketplace()
            {
                Code = CodeParser.Parse(nodeLotPage),
                Cost = CostParser.Parse(node),
                Customer = CustomerParser.Parse(node),
                DateCreated = DateCreatedParser.Parse(node),
                DateFilling = DateFillingParser.Parse(node),
                Description = DescParser.Parse(node),
                SiteId = IdParser.Parse(node),
                SourceLink = absoluteLink.ToString()
            };
            return purchase;
        }

        public SberNodeLotParser(Uri domain, IClient client, INodeParser dateCreatedParser, INodeParser costParser, INodeParser customerParser, INodeParser descParser, INodeParser idParser, INodeParser dateFillingParser, INodeParser codeParser, INodeParser sourceLinkParser) : base(domain, dateCreatedParser, costParser, customerParser, descParser, idParser, dateFillingParser, codeParser, sourceLinkParser)
        {
            _client = client;
        }
    }
}