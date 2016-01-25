using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace ParseZakupki.Parser
{
    public class ZakupkiLotsSpliter : ILotsSpliter
    {
        public IReadOnlyCollection<HtmlNode> DocumentSplit(HtmlDocument doc) =>
            doc
            .DocumentNode
            .SelectNodes(".//div[@class='registerBox registerBoxBank margBtm20']")
            .ToArray();
    }
}
