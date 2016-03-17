using System.Collections.Generic;
using HtmlAgilityPack;
using MarketplaceLocalDB;

namespace ParseZakupki.Parser.Common
{
    public interface IMarketplaceParser
    {
        IReadOnlyCollection<Lot> Parse(HtmlDocument txtDoc);
    }
}
