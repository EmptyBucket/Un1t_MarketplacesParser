using System;
using HtmlAgilityPack;

namespace ParseZakupki.Parser.OTCParser.NodeParser
{
    public class OTCDescriptionParser : INodeParser
    {
        public string Parse(HtmlNode node)
        {
            try
            {
                var desc = node
                    .SelectSingleNode(".//h3[@class='result_item__title']/a/text()")
                    .InnerText
                    .Trim();
                return desc;
            }
            catch (Exception) { return "None" };
        }
    }
}
