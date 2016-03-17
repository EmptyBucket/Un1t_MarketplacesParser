using HtmlAgilityPack;
using MarketplaceLocalDB;

namespace ParseZakupki.Parser.Common
{
    public interface INodeLotParser
    {
        Lot Parse(HtmlNode node);
    }
}
