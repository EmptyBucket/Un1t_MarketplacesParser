using System;
using HtmlAgilityPack;
using ParseZakupki.Client;
using ParseZakupki.Entity;
using ParseZakupki.Parser.Common;

namespace ParseZakupki.Parser.ZakupkiParser
{
    public class ZakupkiNodeLotParser : NodeLotParser
    {
        private readonly IClient _client;

        public ZakupkiNodeLotParser(Uri domain, IClient client, INodeParser dateCreatedParser, INodeParser costParser, INodeParser customerParser, INodeParser descParser, INodeParser idParser, INodeParser dateFillingParser, INodeParser codeParser, INodeParser sourceLinkParser) : base(domain, dateCreatedParser, costParser, customerParser, descParser, idParser, dateFillingParser, codeParser, sourceLinkParser)
        {
            _client = client;
        }

        public override PurchaseInformation Parse(HtmlNode node)
        {
            var relativeLink = SourceLinkParser.Parse(node);
            var absoluteLink = new Uri(Domain, relativeLink);
            var lotPageHtml = _client.GetResult(absoluteLink);
            var htmlDocLotPage = new HtmlDocument();
            htmlDocLotPage.LoadHtml(lotPageHtml);
            var nodeLotPage = htmlDocLotPage.DocumentNode;
            var purchase = new PurchaseInformation()
            {
                DateFilling = DateFillingParser.Parse(nodeLotPage),
                Code = CodeParser.Parse(nodeLotPage),
                SourceLink = absoluteLink.ToString(),
                DateCreated = DateCreatedParser.Parse(node),
                Cost = CostParser.Parse(node),
                Customer = CustomerParser.Parse(node),
                Description = DescParser.Parse(node),
                SiteId = IdParser.Parse(node)
            };
            return purchase;
        }
    }
}
