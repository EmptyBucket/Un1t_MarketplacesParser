﻿using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace ParseZakupki.Parser.OTCParser
{
    public class OTCLotSpliter : ILotsSpliter
    {
        public IReadOnlyCollection<HtmlNode> DocumentSplit(HtmlDocument doc) =>
            doc
            .DocumentNode
            .SelectNodes(".//div[@class='result_item']")
            .ToArray();
    }
}
