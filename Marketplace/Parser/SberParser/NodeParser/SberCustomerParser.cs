using System;
using HtmlAgilityPack;
using ParseZakupki.Parser.Common;

namespace ParseZakupki.Parser.SberParser.NodeParser
{
    public class SberCustomerParser : INodeParser
    {
        public string Parse(HtmlNode node)
        {
            try
            {
                var customer = node
                    .SelectSingleNode(".//td[@content='leaf:orgName']/text()")
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