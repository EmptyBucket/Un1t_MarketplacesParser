using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using ParseZakupki.Parser.Common;

namespace ParseZakupki.Parser.OTCParser
{
    public class OtcLotsSpliter : ILotsSpliter
    {
        public IReadOnlyCollection<HtmlNode> DocumentSplit(HtmlDocument doc) =>
            doc
            .DocumentNode
            .SelectNodes(".//div[@class='result_item']")
            .ToArray();
    }
}
