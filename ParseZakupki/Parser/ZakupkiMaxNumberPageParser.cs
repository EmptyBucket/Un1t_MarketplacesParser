using HtmlAgilityPack;
using Sprache;

namespace ParseZakupki.Parser
{
    public class ZakupkiMaxNumberPageParser : IMaxNumberPageParser
    {
        public int Parse(string txtDoc)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(txtDoc);
            var maxPageNumberToHideJs = htmlDoc.DocumentNode
                .SelectSingleNode(".//li[@class='rightArrow']/a")
                .Attributes["href"]
                .Value;
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
