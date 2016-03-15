using System;
using HtmlAgilityPack;
using ParseZakupki.Parser.Common;

namespace ParseZakupki.Parser.ZakupkiParser.NodeParser
{
    public class ZakupkiSourceLinkParser : INodeParser
    {
        public string Parse(HtmlNode node)
        {
            try
            {
                var link = node
                    .SelectSingleNode(".//td[@class='descriptTenderTd']/dl/dt/a")
                    .Attributes["href"]
                    .Value;
                return link;
            }
            catch (Exception)
            {
                return "None";
            }
        }
    }
}
