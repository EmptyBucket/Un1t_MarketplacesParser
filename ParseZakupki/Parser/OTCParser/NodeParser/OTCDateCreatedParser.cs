using System;
using System.Linq;
using HtmlAgilityPack;

namespace ParseZakupki.Parser.OTCParser.NodeParser
{
    public class OTCDateCreatedParser : INodeParser
    {
        public string Parse(HtmlNode node)
        {
            try
            {
                var dataCreated = node
                    .SelectSingleNode(".//span[@id='BaseMainContent_MainContent_fvCreateDate_lblValue']/text()")
                    .InnerText
                    .Trim()
                    .Split(' ')
                    .Take(2);
                return string.Join(" ", dataCreated);
            }
            catch (Exception)
            {
                return "None";
            }
        }
    }
}
