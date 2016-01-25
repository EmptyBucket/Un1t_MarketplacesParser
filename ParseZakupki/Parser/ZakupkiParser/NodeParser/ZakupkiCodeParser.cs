﻿using System;
using System.Linq;
using HtmlAgilityPack;

namespace ParseZakupki.Parser.ZakupkiParser.NodeParser
{
    public class ZakupkiCodeParser : INodeParser
    {
        public string Parse(HtmlNode node)
        {
            string codes;
            try
            {
                var codesEnum = node
                    .SelectNodes(".//tr[@class='tdHead']/following-sibling::tr[count(td)=6]")
                    .Select(codeNode => codeNode
                        .SelectSingleNode("./td[2]")
                        .InnerText
                        .Trim());
                codes = string.Join(" ", codesEnum);
            }
            catch (Exception)
            {
                codes = "None";
            }
            return codes;
        }
    }
}