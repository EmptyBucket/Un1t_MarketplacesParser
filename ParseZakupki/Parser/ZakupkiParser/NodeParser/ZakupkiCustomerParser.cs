using HtmlAgilityPack;

namespace ParseZakupki.Parser
{
    public class ZakupkiCustomerParser : INodeParser
    {
        public string Parse(HtmlNode node)
        {
            var customer = node
                .SelectSingleNode(".//dd[@class='nameOrganization']/a/text()")
                .InnerText
                .Trim();
            return customer;
        }
    }
}