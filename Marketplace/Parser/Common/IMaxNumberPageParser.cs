using HtmlAgilityPack;

namespace ParseZakupki.Parser.Common
{
    public interface IMaxNumberPageParser
    {
        int Parse(HtmlDocument txtDoc);
    }
}
