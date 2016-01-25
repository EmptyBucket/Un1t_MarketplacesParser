using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using HtmlAgilityPack;
using ParseZakupki.Parser;

namespace ParseZakupki
{
    public class LotUploader
    {
        private readonly IParameters mParameters;
        private readonly IUrlBuilder mUrlBuilder;
        private readonly IClient mClient;
        private readonly IMarketplaceParser mMarketPlaceParser;
        private readonly IMaxNumberPageParser mMaxNumberPageParser;

        public IReadOnlyCollection<PurchaseInformation> FirstUpload(out int maxNumberPage)
        {
            var url = new Uri(mUrlBuilder.Build(mParameters));
            var docTxt = mClient.GetResult(url);
            var docHtml = new HtmlDocument();
            docHtml.LoadHtml(docTxt);
            var parsedResult = mMarketPlaceParser.Parse(docHtml);
            try
            {
                maxNumberPage = mMaxNumberPageParser.Parse(docHtml);
            }
            catch (NullReferenceException)
            {
                maxNumberPage = 1;
            }
            return parsedResult;
        }

        public IReadOnlyCollection<PurchaseInformation> Upload()
        {
            int maxNumberPage;
            var listPurchase = new List<PurchaseInformation>(FirstUpload(out maxNumberPage));
            for (int i = 2; i <= maxNumberPage; i++)
            {
                mParameters.PageNumber = i;
                var tmpUrl = new Uri(mUrlBuilder.Build(mParameters));
                var tmpDocTxt = mClient.GetResult(tmpUrl);
                var docHtml = new HtmlDocument();
                docHtml.LoadHtml(tmpDocTxt);
                var tmpParsedResult = mMarketPlaceParser.Parse(docHtml);
                listPurchase.AddRange(tmpParsedResult);
            }
            return listPurchase.ToArray();
        }

        public async Task<IReadOnlyCollection<PurchaseInformation>> UploadAsync()
        {
            int maxNumberPage;
            var listPurchase = new List<PurchaseInformation>(FirstUpload(out maxNumberPage));
            var listTask = new List<Task<string>>();
            for (int i = 2; i <= maxNumberPage; i++)
            {
                mParameters.PageNumber = i;
                var tmpUrl = new Uri(mUrlBuilder.Build(mParameters));
                listTask.Add(mClient.GetResultAsync(tmpUrl));
            }
            var exceptions = new ConcurrentQueue<Exception>();
            try
            {
                foreach (var docTxt in await Task.WhenAll(listTask))
                {
                    var docHtml = new HtmlDocument();
                    docHtml.Load(docTxt);
                    var tmpParsedResult = mMarketPlaceParser.Parse(docHtml);
                    listPurchase.AddRange(tmpParsedResult);
                }
            }
            catch (Exception e)
            {
                exceptions.Enqueue(e);
            }
            return listPurchase;
        }

        public IReadOnlyCollection<PurchaseInformation> UploadParallel()
        {
            int maxNumberPage;
            var listPurchase = new List<PurchaseInformation>(FirstUpload(out maxNumberPage));
            Parallel.For(2, maxNumberPage + 1, i =>
            {
                mParameters.PageNumber = i;
                var tmpUrl = new Uri(mUrlBuilder.Build(mParameters));
                var tmpDocTxt = mClient.GetResult(tmpUrl);
                var tmpDocHtml = new HtmlDocument();
                tmpDocHtml.Load(tmpDocTxt);
                var tmpParsedResult = mMarketPlaceParser.Parse(tmpDocHtml);
                listPurchase.AddRange(tmpParsedResult);
            });
            return listPurchase;
        }

        public LotUploader(IParameters parameters, IUrlBuilder urlBuilder, IClient client, IMarketplaceParser marketPlaceParser, IMaxNumberPageParser maxNumberPageParser)
        {
            mParameters = parameters;
            mUrlBuilder = urlBuilder;
            mClient = client;
            mMarketPlaceParser = marketPlaceParser;
            mMaxNumberPageParser = maxNumberPageParser;
        }
    }
}
