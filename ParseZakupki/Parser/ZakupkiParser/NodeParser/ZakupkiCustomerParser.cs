using System;
using HtmlAgilityPack;

namespace ParseZakupki.Parser
{
    public class ZakupkiCustomerParser : INodeParser
    {
        public string Parse(HtmlNode node)
        {
            try
            {
                var customer = node
                    .SelectSingleNode(".//dd[@class='nameOrganization']/a/text()")
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