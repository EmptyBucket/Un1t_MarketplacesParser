using HtmlAgilityPack;

namespace ParseZakupki.Parser.OTCParser
{
    public class OTCMaxNumberPageParser : IMaxNumberPageParser
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
