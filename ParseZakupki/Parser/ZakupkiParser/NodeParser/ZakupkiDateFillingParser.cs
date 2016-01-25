using System;
using HtmlAgilityPack;

namespace ParseZakupki.Parser.ZakupkiParser.NodeParser
{
    public class ZakupkiDateFillingParser : INodeParser
    {
        public string Parse(HtmlNode node)
        {
            string startDateFilling = null;
            string endDateFilling = null;
            try
            {
                startDateFilling = node
                    .SelectSingleNode(".//td[contains(text(), 'Дата и время начала') and contains(text(), 'подачи') and contains(text(), 'заявок')]/following-sibling::td/text()")
                    .InnerText
                    .Trim();
            }
            catch (Exception) { }
            try
            {
                endDateFilling = node
                    .SelectSingleNode(".//td[contains(text(), 'Дата и время начала') and contains(text(), 'подачи') and contains(text(), 'заявок')]/following-sibling::td/text()")
                    .InnerText
                    .Trim();
            }
            catch (Exception) { }
            return startDateFilling == null && endDateFilling == null ? "None" : startDateFilling ?? string.Empty + " - " + endDateFilling ?? string.Empty;
        }
    }
}
