using System;
using HtmlAgilityPack;
using ParseZakupki.Parser.Common;

namespace ParseZakupki.Parser.ZakupkiParser.NodeParser
{
    public class ZakupkiDateCreatedParser : INodeParser
    {
        public string Parse(HtmlNode node)
        {
            try
            {
                var createdNode = node
                    .SelectSingleNode(".//td[@class='amountTenderTd']/ul/li[1]/text()");
                var created = createdNode
                    .InnerHtml
                    .Trim();
                return created;
            }
            catch(Exception)
            {
                return "None";
            }
        }
    }
}
