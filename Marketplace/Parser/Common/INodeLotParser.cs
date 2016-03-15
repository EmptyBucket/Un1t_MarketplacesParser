using HtmlAgilityPack;
using MarketplaceDB;
using ParseZakupki.Entity;

namespace ParseZakupki.Parser.Common
{
    public interface INodeLotParser
    {
        Marketplace Parse(HtmlNode node);
    }
}
