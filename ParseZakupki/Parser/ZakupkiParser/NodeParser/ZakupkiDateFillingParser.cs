using System;
using System.Linq;
using HtmlAgilityPack;

namespace ParseZakupki.Parser.ZakupkiParser.NodeParser
{
    public class ZakupkiDateFillingParser : INodeParser
    {
        public string Parse(HtmlNode node)
        {
            string dateFilling;
            try
            {
                dateFilling = string.Join(" ", node
                    .SelectNodes(".//td[contains(text(), 'подачи заявок')]/following-sibling::td/text()")
                    .Select(nodeFilling => nodeFilling.InnerText.Trim()));
            }
            catch (Exception)
            {
                dateFilling = "None";
            }
            return dateFilling;
        }
    }
}
