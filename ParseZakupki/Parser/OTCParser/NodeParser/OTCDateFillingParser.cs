using System;
using HtmlAgilityPack;

namespace ParseZakupki.Parser.OTCParser.NodeParser
{
    public class OTCDateFillingParser : INodeParser
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
            catch(Exception) {  }
            string dateFillingEnd = null;
            try
            {
                dateFillingEnd = node
                    .SelectSingleNode(".//span[@class='result_item__worktime_date']/text()")
                    .InnerText
                    .Trim();
            }
            catch (Exception) { }
            return dateFillingStart == null && dateFillingEnd == null ? "None" : dateFillingStart ?? string.Empty + " - " + dateFillingEnd ?? string.Empty;
        }
    }
}
