using System.Collections.Generic;
using HtmlAgilityPack;
using MarketplaceDB;
using ParseZakupki.Entity;

namespace ParseZakupki.Parser.Common
{
    public interface IMarketplaceParser
    {
        IReadOnlyCollection<Marketplace> Parse(HtmlDocument txtDoc);
    }
}
