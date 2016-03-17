using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using ParseZakupki.Parser.Common;

namespace ParseZakupki.Parser.ZakupkiParser
{
    public class ZakupkiLotSpliter : ILotSpliter
    {
        public IReadOnlyCollection<HtmlNode> DocumentSplit(HtmlDocument doc)
        {
            try
            {
                return doc
                .DocumentNode
                .SelectNodes(".//div[@class='registerBox registerBoxBank margBtm20']")
                .Take(10)
                .ToArray();
            }
            catch (Exception)
            {
                return new HtmlNode[0];
            }
        }
    }
}
