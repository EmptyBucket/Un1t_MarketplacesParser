using System;
using HtmlAgilityPack;
using ParseZakupki.Parser.Common;

namespace ParseZakupki.Parser.SberParser.NodeParser
{
    public class SberDescriptionParser : INodeParser
    {
        public string Parse(HtmlNode node)
        {
            try
            {
                var desc = node
                    .SelectSingleNode(".//td[@content='leaf:purchName'/text()")
                    .InnerText
                    .Trim();
                return desc;
            }
            catch (Exception)
            {
                return "None";
            }
        }
    }
}