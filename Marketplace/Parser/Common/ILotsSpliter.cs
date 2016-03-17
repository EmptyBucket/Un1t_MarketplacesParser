using System.Collections.Generic;
using HtmlAgilityPack;

namespace ParseZakupki.Parser.Common
{
    public interface ILotSpliter
    {
        IReadOnlyCollection<HtmlNode> DocumentSplit(HtmlDocument doc);
    }
}
