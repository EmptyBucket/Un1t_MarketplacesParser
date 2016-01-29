using System;
using HtmlAgilityPack;
using ParseZakupki.Parser.Common;

namespace ParseZakupki.Parser.SberParser.NodeParser
{
    public class SberCodeParser : INodeParser
    {
        public string Parse(HtmlNode node)
        {
            try
            {
                var code = node
                    .SelectSingleNode(".//td[@content='leaf:code'/text()")
                    .InnerText
                    .Trim();
                return code;
            }
            catch (Exception)
            {
                return "None";
            }
        }
    }
}