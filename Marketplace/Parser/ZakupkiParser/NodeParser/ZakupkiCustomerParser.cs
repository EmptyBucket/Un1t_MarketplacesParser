using System;
using HtmlAgilityPack;
using ParseZakupki.Parser.Common;

namespace ParseZakupki.Parser.ZakupkiParser.NodeParser
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