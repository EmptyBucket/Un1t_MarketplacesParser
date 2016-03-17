using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using HtmlAgilityPack;
using MarketplaceLocalDB;
using ParseZakupki.Client;
using ParseZakupki.Parameter.Common;
using ParseZakupki.Parser.Common;
using ParseZakupki.UrlBuilder;

namespace ParseZakupki.LotUpload
{
    public class LotUploader : ILotUploader
    {
        private readonly IClient _client;
        private readonly IMarketplaceParser _marketPlaceParser;
        private readonly IMaxNumberPageParser _maxNumberPageParser;
        private readonly IPageParameter _parameter;
        private readonly IUrlBuilder _urlBuilder;

        public LotUploader(IPageParameter parameter, IUrlBuilder urlBuilder, IClient client,
            IMarketplaceParser marketPlaceParser, IMaxNumberPageParser maxNumberPageParser)
        {
            _parameter = parameter;
            _urlBuilder = urlBuilder;
            _client = client;
            _marketPlaceParser = marketPlaceParser;
            _maxNumberPageParser = maxNumberPageParser;
        }

        public IReadOnlyCollection<Lot> Upload()
        {
            int maxNumberPage;
            var listPurchase = new List<Lot>(FirstUpload(out maxNumberPage));
            for (var i = 2; i <= maxNumberPage; i++)
            {
                _parameter.PageNumber = i;
                var tmpUrl = new Uri(_urlBuilder.Build(_parameter));
                var tmpDocTxt = _client.GetResult(tmpUrl);
                var docHtml = new HtmlDocument();
                docHtml.LoadHtml(tmpDocTxt);
                var tmpParsedResult = _marketPlaceParser.Parse(docHtml);
                listPurchase.AddRange(tmpParsedResult);
            }
            return listPurchase.ToArray();
        }

        public IReadOnlyCollection<Lot> FirstUpload(out int maxNumberPage)
        {
            var url = new Uri(_urlBuilder.Build(_parameter));
            var docTxt = _client.GetResult(url);
            var docHtml = new HtmlDocument();
            docHtml.LoadHtml(docTxt);
            var parsedResult = _marketPlaceParser.Parse(docHtml);
            try
            {
                maxNumberPage = _maxNumberPageParser.Parse(docHtml);
            }
            catch (NullReferenceException)
            {
                maxNumberPage = 1;
            }
            return parsedResult;
        }

        public async Task<IReadOnlyCollection<Lot>> UploadAsync()
        {
            int maxNumberPage;
            var listPurchase = new List<Lot>(FirstUpload(out maxNumberPage));
            var listTask = new List<Task<string>>();
            for (var i = 2; i <= maxNumberPage; i++)
            {
                _parameter.PageNumber = i;
                var tmpUrl = new Uri(_urlBuilder.Build(_parameter));
                listTask.Add(_client.GetResultAsync(tmpUrl));
            }
            var exceptions = new ConcurrentQueue<Exception>();
            try
            {
                foreach (var docTxt in await Task.WhenAll(listTask))
                {
                    var docHtml = new HtmlDocument();
                    docHtml.Load(docTxt);
                    var tmpParsedResult = _marketPlaceParser.Parse(docHtml);
                    listPurchase.AddRange(tmpParsedResult);
                }
            }
            catch (Exception e)
            {
                exceptions.Enqueue(e);
            }
            return listPurchase;
        }

        public IReadOnlyCollection<Lot> UploadParallel()
        {
            int maxNumberPage;
            var listPurchase = new List<Lot>(FirstUpload(out maxNumberPage));
            Parallel.For(2, maxNumberPage + 1, i =>
            {
                _parameter.PageNumber = i;
                var tmpUrl = new Uri(_urlBuilder.Build(_parameter));
                var tmpDocTxt = _client.GetResult(tmpUrl);
                var tmpDocHtml = new HtmlDocument();
                tmpDocHtml.Load(tmpDocTxt);
                var tmpParsedResult = _marketPlaceParser.Parse(tmpDocHtml);
                listPurchase.AddRange(tmpParsedResult);
            });
            return listPurchase;
        }
    }
}