using HtmlAgilityPack;

namespace ParseZakupki.Parser
{
    public interface IMaxNumberPageParser
    {
        int Parse(HtmlDocument txtDoc);
    }
}
