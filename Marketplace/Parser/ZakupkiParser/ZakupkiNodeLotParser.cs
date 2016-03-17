using System;
using HtmlAgilityPack;
using MarketplaceLocalDB;
using ParseZakupki.Client;
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

        private int _counter = 0;

        public override Lot Parse(HtmlNode node)
        {
            Console.WriteLine(_counter++);
            var relativeLink = SourceLinkParser.Parse(node);
            var absoluteLink = new Uri(Domain, relativeLink);
            var lotPageHtml = _client.GetResult(absoluteLink);
            var htmlDocLotPage = new HtmlDocument();
            htmlDocLotPage.LoadHtml(lotPageHtml);
            var nodeLotPage = htmlDocLotPage.DocumentNode;
            var dateFilling = DateFillingParser.Parse(nodeLotPage);
            var purchase = new Lot()
            {
                DateStart = dateFilling == "None" ? string.Empty : dateFilling.Split('-')[0].Trim(),
                DateEnd = dateFilling == "None" ? string.Empty : dateFilling.Split('-')[1].Trim(),
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
