﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using MarketplaceLocalDB;
using ParseZakupki.Parameter.Common;
using ParseZakupki.Parser.Common;
using ParseZakupki.UrlBuilder;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace ParseZakupki.LotUpload
{
    public class LotUploaderJs : ILotUploader
    {
        private readonly IMarketplaceParser _marketPlaceParser;
        private readonly IParameter _parameter;
        private readonly IUrlBuilder _urlBuilder;
        private readonly List<Lot> _purchaseInfo = new List<Lot>();
        private WebBrowser _webBrowser;
        private bool _complete;

        private void RunWebBrowserThread()
        {
            var thread = new Thread(() =>
            {
                var url = new Uri(_urlBuilder.Build(_parameter));
                _webBrowser = new WebBrowser();
                _webBrowser.DocumentCompleted += FirstDocumentCompleted;
                _webBrowser.Navigate(url);

                Form form = new Form();
                form.Controls.Add(_webBrowser);
                form.ShowInTaskbar = false;
                form.WindowState = FormWindowState.Minimized;

                Application.Run(form);
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void FirstDocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs webBrowserDocumentCompletedEventArgs)
        {
            _webBrowser.DocumentCompleted -= FirstDocumentCompleted;
            Thread.Sleep(60000);
            var document = _webBrowser.Document;
            var documentText = _webBrowser.DocumentText;

            if (document != null)
            {
                var publishDateFrom = document.GetElementById("phWorkZone_phFilterZone_nbtPurchaseListFilter_cldPublicDateStart");
                publishDateFrom?.SetAttribute("value", _parameter.PublishDateFrom.ToString("d"));

                var publishDateTo = document.GetElementById("phWorkZone_phFilterZone_nbtPurchaseListFilter_cldPublicDateEnd");
                publishDateTo?.SetAttribute("value", _parameter.PublishDateTo.ToString("d"));

                var costFrom = document.GetElementById("phWorkZone_phFilterZone_nbtPurchaseListFilter_purchamountstart");
                costFrom?.SetAttribute("value", _parameter.CostFrom.ToString());

                var costTo = document.GetElementById("phWorkZone_phFilterZone_nbtPurchaseListFilter_purchamountend");
                costTo?.SetAttribute("value", _parameter.ToString());

                var buttonSearch = document.GetElementById("phWorkZone_phFilterZone_btnSearch");
                if (buttonSearch == null) return;
                buttonSearch.Click += ButtonSearch_Click;
                buttonSearch.InvokeMember("click");
            }
            _complete = true;
        }

        private void ButtonSearch_Click(object sender, HtmlElementEventArgs e)
        {
            var docTxt = _webBrowser.DocumentText;
            var docHtml = new HtmlDocument();
            docHtml.LoadHtml(docTxt);
            var parsedResult = _marketPlaceParser.Parse(docHtml);
            _purchaseInfo.AddRange(parsedResult);

            var url = _webBrowser.Document?.GetElementById("phWorkZone_nextPage")?.GetAttribute("href");
            if(url == null)
            {
                _complete = true;
                return;
            }

            var uri = new Uri(url);
            _webBrowser.DocumentCompleted += NextUploadComplete;
            _webBrowser.Navigate(uri);
        }

        private void NextUploadComplete(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            var docTxt = _webBrowser.DocumentText;
            var docHtml = new HtmlDocument();
            docHtml.LoadHtml(docTxt);
            var parsedResult = _marketPlaceParser.Parse(docHtml);
            _purchaseInfo.AddRange(parsedResult);

            var url = _webBrowser.Document?.GetElementById("phWorkZone_nextPage")?.GetAttribute("href");
            if (url == null)
            {
                _complete = true;
                return;
            }
            var uri = new Uri(url);
            _webBrowser.Navigate(uri);
        }

        public IReadOnlyCollection<Lot> Upload()
        {
            RunWebBrowserThread();
            while (!_complete)
            {
                
            }
            return _purchaseInfo;
        }

        public LotUploaderJs(IParameter parameter, IUrlBuilder urlBuilder, IMarketplaceParser marketPlaceParser)
        {
            _parameter = parameter;
            _urlBuilder = urlBuilder;
            _marketPlaceParser = marketPlaceParser;
        }
    }
}