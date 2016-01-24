using System.Web;
using HtmlAgilityPack;

namespace ParseZakupki.Parser
{
    public class ZakupkiDescriptionParser : INodeParser
    {
        public string Parse(HtmlNode node)
        {
            var desc = node
                .SelectSingleNode(".//td[@class='descriptTenderTd']/dl/dd[2]/text()")
                .InnerText
                .Trim();
            var decodedDesc = HttpUtility.HtmlDecode(desc);
            return decodedDesc;
        }
    }
}