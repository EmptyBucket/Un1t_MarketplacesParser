using HtmlAgilityPack;

namespace ParseZakupki.Parser.Common
{
    public interface INodeParser
    {
        string Parse(HtmlNode node);
    }
}
