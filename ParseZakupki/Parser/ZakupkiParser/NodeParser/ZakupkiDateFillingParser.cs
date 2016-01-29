using System;
using HtmlAgilityPack;
using ParseZakupki.Parser.Common;

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
            catch (Exception)
            {
                // ignored
            }
            try
            {
                endDateFilling = node
                    .SelectSingleNode(".//td[contains(text(), 'Дата и время окончания') and contains(text(), 'подачи') and contains(text(), 'заявок')]/following-sibling::td/text()")
                    .InnerText
                    .Trim();
            }
            catch (Exception)
            {
                // ignored
            }
            var result = startDateFilling == null && endDateFilling == null ? "None" : (startDateFilling ?? string.Empty) + " - " + (endDateFilling ?? string.Empty);
            return result;
        }
    }
}
