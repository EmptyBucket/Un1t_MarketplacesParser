using HtmlAgilityPack;

namespace ParseZakupki.Parser.OTCParser.NodeParser
{
    public class OTCCustomerParser : INodeParser
    {
        public string Parse(HtmlNode node)
        {
            var customer = node
                .SelectSingleNode(".//span[@class='Expander']/a/text()")
                .InnerText
                .Trim();
            return customer;
        }
    }
}
