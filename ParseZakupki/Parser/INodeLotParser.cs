using HtmlAgilityPack;

namespace ParseZakupki.Parser
{
    public interface INodeLotParser
    {
        PurchaseInformation Parse(HtmlNode node);
    }
}
