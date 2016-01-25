using System;
using HtmlAgilityPack;

namespace ParseZakupki.Parser
{
    public class ZakupkiIdParser : INodeParser
    {
        public string Parse(HtmlNode node)
        {
            try
            {
                var id = node
                    .SelectSingleNode(".//td[@class='descriptTenderTd']/dl/dt/a/text()")
                    .InnerText
                    .Trim();
                return id;
            }
            catch (Exception)
            {
                return "None";
            }
        }
    }
}