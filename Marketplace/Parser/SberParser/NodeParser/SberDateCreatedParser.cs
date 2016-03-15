using System;
using HtmlAgilityPack;
using ParseZakupki.Parser.Common;

namespace ParseZakupki.Parser.SberParser.NodeParser
{
    public class SberDateCreatedParser : INodeParser
    {
        public string Parse(HtmlNode node)
        {
            try
            {
                var dateCreated = node
                .SelectSingleNode(".//td[@content='leaf:publicDateStr']/text()")
                .InnerText
                .Trim();
                return dateCreated;
            }
            catch (Exception)
            {
                return "None";
            }
        }
    }
}