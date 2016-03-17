using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using ParseZakupki.Parser.Common;

namespace ParseZakupki.Parser.SberParser
{
    public class SberLotpliter : ILotSpliter
    {
        public IReadOnlyCollection<HtmlNode> DocumentSplit(HtmlDocument doc)
        {
            var nodes = doc
                .DocumentNode
                .SelectNodes(".//tr[@content='node:row']")
                .ToArray();
            return nodes;
        }
    }
}