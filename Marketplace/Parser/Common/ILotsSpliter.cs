using System.Collections.Generic;
using HtmlAgilityPack;

namespace ParseZakupki.Parser.Common
{
    public interface ILotsSpliter
    {
        IReadOnlyCollection<HtmlNode> DocumentSplit(HtmlDocument doc);
    }
}
