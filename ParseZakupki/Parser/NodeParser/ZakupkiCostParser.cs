using System;
using HtmlAgilityPack;

namespace ParseZakupki.Parser
{
    public class ZakupkiCostParser : INodeParser
    {
        public string Parse(HtmlNode node)
        {
            string result;
            try
            {
                var costNode = node
                    .SelectSingleNode(".//span[@class='currency']/..");
                var cost = costNode
                    .SelectSingleNode("./strong/text()")
                    .InnerText
                    .Trim();
                var res = costNode
                    .SelectSingleNode("./strong/span/text()")
                    .InnerText
                    .Trim();
                var currency = costNode
                    .SelectSingleNode("./span/text()")
                    .InnerText
                    .Trim();
                result = cost + res + ' ' + currency;
            }
            catch (Exception)
            {
                result = "There is no";
            }
            return result;
        }
    }
}
