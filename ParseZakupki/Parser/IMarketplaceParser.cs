using System.Collections.Generic;
using HtmlAgilityPack;

namespace ParseZakupki.Parser
{
    public interface IMarketplaceParser
    {
        IReadOnlyCollection<PurchaseInformation> Parse(HtmlDocument txtDoc);
    }
}
