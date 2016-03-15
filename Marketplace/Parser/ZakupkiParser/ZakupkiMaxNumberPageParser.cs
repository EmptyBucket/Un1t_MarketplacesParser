using HtmlAgilityPack;
using ParseZakupki.Parser.Common;
using Sprache;

namespace ParseZakupki.Parser.ZakupkiParser
{
    public class ZakupkiMaxNumberPageParser : IMaxNumberPageParser
    {
        public int Parse(HtmlDocument htmlDoc)
        {
            var maxPageNumberToHideJs = htmlDoc.DocumentNode
                .SelectSingleNode(".//li[@class='rightArrow']/a/@href")
                .InnerText
                .Trim();
            var maxNumberPageParser =
                from trash in Sprache.Parse.AnyChar.Except(Sprache.Parse.Digit).Many()
                from number in Sprache.Parse.Decimal
                select number;
            var parsedMaxNumberPage =
                maxNumberPageParser.Parse(maxPageNumberToHideJs);
            var parsedIntMaxNumberPage = int.Parse(parsedMaxNumberPage);
            return parsedIntMaxNumberPage;
        }
    }
}
