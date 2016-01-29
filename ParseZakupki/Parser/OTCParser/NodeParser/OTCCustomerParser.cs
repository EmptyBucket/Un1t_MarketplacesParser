using System;
using HtmlAgilityPack;
using ParseZakupki.Parser.Common;

namespace ParseZakupki.Parser.OTCParser.NodeParser
{
    public class OtcCustomerParser : INodeParser
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
