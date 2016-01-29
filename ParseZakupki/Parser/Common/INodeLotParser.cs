using HtmlAgilityPack;
using ParseZakupki.Entity;

namespace ParseZakupki.Parser.Common
{
    public interface INodeLotParser
    {
        PurchaseInformation Parse(HtmlNode node);
    }
}
