using System.Collections.Generic;
using HtmlAgilityPack;
using ParseZakupki.Entity;

namespace ParseZakupki.Parser.Common
{
    public interface IMarketplaceParser
    {
        IReadOnlyCollection<PurchaseInformation> Parse(HtmlDocument txtDoc);
    }
}
