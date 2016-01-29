using System;
using HtmlAgilityPack;
using ParseZakupki.Parser.Common;

namespace ParseZakupki.Parser.OTCParser.NodeParser
{
    public class OtcDateFillingParser : INodeParser
    {
        public string Parse(HtmlNode node)
        {
            string dateFillingStart = null;
            try
            {
                dateFillingStart = node
                    .SelectSingleNode(".//span[@class='result_item__worktime_date']/text()")
                    .InnerText
                    .Trim();
            }
            catch (Exception)
            {
                // ignored
            }
            string dateFillingEnd = null;
            try
            {
                dateFillingEnd = node
                    .SelectSingleNode(".//span[@class='result_item__worktime_date']/text()")
                    .InnerText
                    .Trim();
            }
            catch (Exception)
            {
                // ignored
            }
            return dateFillingStart == null && dateFillingEnd == null ? "None" : (dateFillingStart ?? string.Empty) + " - " + (dateFillingEnd ?? string.Empty);
        }
    }
}
