using System;
using HtmlAgilityPack;

namespace ParseZakupki.Parser.OTCParser
{
    public class OTCNodeLotParser : NodeLotParser
    {
        public OTCNodeLotParser(Uri domain, IClient client, INodeParser dateCreatedParser, INodeParser costParser, INodeParser customerParser, INodeParser descParser, INodeParser idParser, INodeParser dateFiilingParser, INodeParser codeParser, INodeParser sourceLinkParser) : base(domain, client, dateCreatedParser, costParser, customerParser, descParser, idParser, dateFiilingParser, codeParser, sourceLinkParser)
        {
        }

        public override PurchaseInformation Parse(HtmlNode node)
        {
            var absoluteLink = mSourceLinkParser.Parse(node);
            var lotPageHtml = mClient.GetResult(new Uri(absoluteLink));
            var htmlDocLotPage = new HtmlDocument();
            htmlDocLotPage.LoadHtml(lotPageHtml);
            var nodeLotPage = htmlDocLotPage.DocumentNode;
            var purchase = new PurchaseInformation()
            {
                DateFilling = mDateFillingParser.Parse(node),
                Code = mCodeParser.Parse(nodeLotPage),
                SourceLink = absoluteLink,
                DateCreated = mDateCreatedParser.Parse(nodeLotPage),
                Cost = mCostParser.Parse(node),
                Customer = mCustomerParser.Parse(node),
                Description = mDescParser.Parse(node),
                SiteId = mIdParser.Parse(node)
            };
            return purchase;
        }
    }
}
