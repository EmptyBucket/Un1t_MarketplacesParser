using System;
using HtmlAgilityPack;
using ParseZakupki.Parser.Common;

namespace ParseZakupki.Parser.SberParser.NodeParser
{
    public class SberIdParser : INodeParser
    {
        public string Parse(HtmlNode node)
        {
            try
            {
                var id = node
                    .SelectSingleNode(".//td[@content='leaf:purchCode']/text()")
                    .InnerText
                    .Trim();
                return id;
            }
            catch (Exception)
            {
                return "None";
            }
        }
    }
}