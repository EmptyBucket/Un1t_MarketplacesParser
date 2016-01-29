using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using ParseZakupki.Entity;
using ParseZakupki.Parameter.Common;
using ParseZakupki.Parser.Common;
using ParseZakupki.UrlBuilder;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace ParseZakupki.LotUpload
{
    public class LotUploaderJs : ILotUploader
    {
        private readonly IMarketplaceParser _marketPlaceParser;
        private readonly IParameters _parameters;
        private readonly IUrlBuilder _urlBuilder;
        private readonly List<PurchaseInformation> _purchaseInfo = new List<PurchaseInformation>();
        private WebBrowser _webBrowser;
        private bool _complete;

        private void RunWebBrowserThread()
        {
            var thread = new Thread(() =>
            {
                var url = new Uri(_urlBuilder.Build(_parameters));
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
                publishDateFrom?.SetAttribute("value", _parameters.PublishDateFrom.ToString("d"));

                var publishDateTo = document.GetElementById("phWorkZone_phFilterZone_nbtPurchaseListFilter_cldPublicDateEnd");
                publishDateTo?.SetAttribute("value", _parameters.PublishDateTo.ToString("d"));

                var costFrom = document.GetElementById("phWorkZone_phFilterZone_nbtPurchaseListFilter_purchamountstart");
                costFrom?.SetAttribute("value", _parameters.CostFrom.ToString());

                var costTo = document.GetElementById("phWorkZone_phFilterZone_nbtPurchaseListFilter_purchamountend");
                costTo?.SetAttribute("value", _parameters.ToString());

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

        public IReadOnlyCollection<PurchaseInformation> Upload()
        {
            RunWebBrowserThread();
            while (!_complete)
            {
                
            }
            return _purchaseInfo;
        }

        public LotUploaderJs(IParameters parameters, IUrlBuilder urlBuilder, IMarketplaceParser marketPlaceParser)
        {
            _parameters = parameters;
            _urlBuilder = urlBuilder;
            _marketPlaceParser = marketPlaceParser;
        }
    }
}