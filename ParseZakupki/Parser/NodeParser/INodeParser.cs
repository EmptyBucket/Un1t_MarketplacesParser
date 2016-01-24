using HtmlAgilityPack;

namespace ParseZakupki.Parser
{
    public interface INodeParser
    {
        string Parse(HtmlNode node);
    }
}
