﻿using HtmlAgilityPack;

namespace ParseZakupki.Parser.OTCParser.NodeParser
{
    public class OTCSourceLinkParser : INodeParser
    {
        public string Parse(HtmlNode node)
        {
            var sourceLink = node
                .SelectSingleNode(".//h3[@class='result_item__title']/a/@href")
                .InnerText
                .Trim();
            return sourceLink;
        }
    }
}
