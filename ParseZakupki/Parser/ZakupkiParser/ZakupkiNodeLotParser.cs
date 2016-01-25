using System;
using HtmlAgilityPack;

namespace ParseZakupki.Parser.ZakupkiParser
{
    public class ZakupkiNodeLotParser : NodeLotParser
    {
        public ZakupkiNodeLotParser(Uri domain, IClient client, INodeParser dateCreatedParser, INodeParser costParser, INodeParser customerParser, INodeParser descParser, INodeParser idParser, INodeParser dateFiilingParser, INodeParser codeParser, INodeParser sourceLinkParser) : base(domain, client, dateCreatedParser, costParser, customerParser, descParser, idParser, dateFiilingParser, codeParser, sourceLinkParser)
        {
        }

        public override PurchaseInformation Parse(HtmlNode node)
        {
            var relativeLink = mSourceLinkParser.Parse(node);
            var absoluteLink = new Uri(mDomain, relativeLink);
            var lotPageHtml = mClient.GetResult(absoluteLink);
            var htmlDocLotPage = new HtmlDocument();
            htmlDocLotPage.LoadHtml(lotPageHtml);
            var nodeLotPage = htmlDocLotPage.DocumentNode;
            var purchase = new PurchaseInformation()
            {
                DateFilling = mDateFillingParser.Parse(nodeLotPage),
                Code = mCodeParser.Parse(nodeLotPage),
                SourceLink = absoluteLink.ToString(),
                DateCreated = mDateCreatedParser.Parse(node),
                Cost = mCostParser.Parse(node),
                Customer = mCustomerParser.Parse(node),
                Description = mDescParser.Parse(node),
                SiteId = mIdParser.Parse(node)
            };
            return purchase;
        }
    }
}
