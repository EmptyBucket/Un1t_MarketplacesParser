using System;
using HtmlAgilityPack;

namespace ParseZakupki.Parser
{
    public class ZakupkiCostParser : INodeParser
    {
        private static string NoBreakSpace = '\u00A0'.ToString();

        public string Parse(HtmlNode node)
        {
            try
            {
                var costNode = node
                    .SelectSingleNode(".//span[@class='currency']/..");
                var cost = costNode
                    .SelectSingleNode("./strong/text()")
                    .InnerText
                    .Trim()
                    .Replace(NoBreakSpace, string.Empty);
                var res = costNode
                    .SelectSingleNode("./strong/span/text()")
                    .InnerText
                    .Trim();
                var currency = costNode
                    .SelectSingleNode("./span/text()")
                    .InnerText
                    .Trim();
                var result = cost + res + ' ' + currency;
                return result;
            }
            catch (Exception)
            {
                return "None";
            }
        }
    }
}
