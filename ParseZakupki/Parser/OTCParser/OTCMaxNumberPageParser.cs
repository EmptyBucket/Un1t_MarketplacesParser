using HtmlAgilityPack;
using ParseZakupki.Parser.Common;

namespace ParseZakupki.Parser.OTCParser
{
    public class OtcMaxNumberPageParser : IMaxNumberPageParser
    {
        public int Parse(HtmlDocument htmlDoc)
        {
            var maxNumberPage = htmlDoc
                .DocumentNode
                .SelectSingleNode(".//span[@class='last']/@data-pageindex")
                .InnerText
                .Trim();
            return int.Parse(maxNumberPage);
        }
    }
}
