using HtmlAgilityPack;

namespace ParseZakupki.Parser
{
    public interface INodeContestParser
    {
        PurchaseInformation Parse(HtmlNode node);
    }
}
