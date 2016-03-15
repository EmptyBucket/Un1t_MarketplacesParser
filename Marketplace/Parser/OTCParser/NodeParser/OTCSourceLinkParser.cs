using System;
using HtmlAgilityPack;
using ParseZakupki.Parser.Common;

namespace ParseZakupki.Parser.OTCParser.NodeParser
{
    public class OtcSourceLinkParser : INodeParser
    {
        public string Parse(HtmlNode node)
        {
            try
            {
                var sourceLink = node
                    .SelectSingleNode(".//h3[@class='result_item__title']/a")
                    .Attributes["href"]
                    .Value;
                return sourceLink;
            }
            catch(Exception)
            {
                return "None";
            }
        }
    }
}
