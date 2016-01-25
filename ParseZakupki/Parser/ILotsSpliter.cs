using System.Collections.Generic;
using HtmlAgilityPack;

namespace ParseZakupki.Parser
{
    public interface ILotsSpliter
    {
        IReadOnlyCollection<HtmlNode> DocumentSplit(HtmlDocument doc);
    }
}
