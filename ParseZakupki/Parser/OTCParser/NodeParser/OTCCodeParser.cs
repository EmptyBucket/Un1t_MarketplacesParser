using System;
using System.Linq;
using HtmlAgilityPack;

namespace ParseZakupki.Parser.OTCParser.NodeParser
{
    public class OTCCodeParser : INodeParser
    {
        public string Parse(HtmlNode node)
        {
            string codeOKVED = null;
            try
            {
                codeOKVED = node
                    .SelectSingleNode(".//span[@id='BaseMainContent_MainContent_ucTradeLotViewList_rptLots_ucTradeLotView_0_fvOkved2_0_lblValue_0']/text()")
                    .InnerText
                    .Trim()
                    .Split(' ')
                    .First();
            }
            catch (Exception) { }
            string codeOKPD = null;
            try
            {
                codeOKPD = node
                .SelectSingleNode(".//span[@id='BaseMainContent_MainContent_ucTradeLotViewList_rptLots_ucTradeLotView_0_fvOkpd2_0_lblValue_0']/text()")
                .InnerText
                .Trim()
                .Split(' ')
                .First();
            }
            catch (Exception) { }
            return codeOKVED ?? string.Empty + (codeOKVED != null ? ' ' + codeOKVED : string.Empty);
        }
    }
}
