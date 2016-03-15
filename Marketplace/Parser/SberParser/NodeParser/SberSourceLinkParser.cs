using System;
using HtmlAgilityPack;
using ParseZakupki.Parser.Common;

namespace ParseZakupki.Parser.SberParser.NodeParser
{
    public class SberSourceLinkParser : INodeParser
    {
        public string Parse(HtmlNode node)
        {
            try
            {
                var link = node
                    .SelectSingleNode("./td[1]/a")
                    .Attributes["hread"]
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