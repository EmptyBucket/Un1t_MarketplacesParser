using System;
using HtmlAgilityPack;

namespace ParseZakupki.Parser.OTCParser.NodeParser
{
    public class OTCCustomerParser : INodeParser
    {
        public string Parse(HtmlNode node)
        {
            try
            {
                var customer = node
                    .SelectSingleNode(".//span[@class='Expander']/a/text()")
                    .InnerText
                    .Trim();
                return customer;
            }
            catch (Exception)
            {
                return "None";
            }
        }
    }
}
