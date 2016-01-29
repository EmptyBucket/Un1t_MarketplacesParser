using System;
using System.Linq;
using HtmlAgilityPack;
using ParseZakupki.Parser.Common;

namespace ParseZakupki.Parser.OTCParser.NodeParser
{
    public class OtcCodeParser : INodeParser
    {
        public string Parse(HtmlNode node)
        {
            string codeOkved = null;
            try
            {
                codeOkved = node
                    .SelectSingleNode(".//span[@id='BaseMainContent_MainContent_ucTradeLotViewList_rptLots_ucTradeLotView_0_fvOkved2_0_lblValue_0']/text()")
                    .InnerText
                    .Trim()
                    .Split(' ')
                    .First();
            }
            catch (Exception)
            {
                // ignored
            }
            string codeOkpd = null;
            try
            {
                codeOkpd = node
                .SelectSingleNode(".//span[@id='BaseMainContent_MainContent_ucTradeLotViewList_rptLots_ucTradeLotView_0_fvOkpd2_0_lblValue_0']/text()")
                .InnerText
                .Trim()
                .Split(' ')
                .First();
            }
            catch (Exception)
            {
                // ignored
            }
            return codeOkved ?? string.Empty + (codeOkpd != null ? ' ' + codeOkpd : string.Empty);
        }
    }
}
