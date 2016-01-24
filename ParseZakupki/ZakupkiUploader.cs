using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using ParseZakupki.Parameter;
using ParseZakupki.Parser;

namespace ParseZakupki
{
    public class ZakupkiUploader
    {
        private readonly ZakupkiParameters mParameters;
        private readonly IUrlBuilder mUrlBuilder;
        private readonly IClient mClient;
        private readonly IMarketplaceParser mMarketPlaceParser;
        private readonly IMaxNumberPageParser mMaxNumberPageParser;

        public IReadOnlyCollection<PurchaseInformation> FirstUpload(out int maxNumberPage)
        {
            string url = mUrlBuilder.Build(mParameters);
            var result = mClient.GetResult(url);
            var parsedResult = mMarketPlaceParser.Parse(result);

            try
            {
                maxNumberPage = mMaxNumberPageParser.Parse(result);
            }
            catch (System.NullReferenceException)
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
                string tmpUrl = mUrlBuilder.Build(mParameters);
                var tmpResult = mClient.GetResult(tmpUrl);
                var tmpParsedResult = mMarketPlaceParser.Parse(tmpResult);
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
                string tmpUrl = mUrlBuilder.Build(mParameters);
                listTask.Add(mClient.GetResultAsync(tmpUrl));
            }
            var exceptions = new ConcurrentQueue<Exception>();
            try
            {
                foreach (var result in await Task.WhenAll(listTask))
                {
                    var tmpParsedResult = mMarketPlaceParser.Parse(result);
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
                string tmpUrl = mUrlBuilder.Build(mParameters);
                var tmpResult = mClient.GetResult(tmpUrl);
                var tmpParsedResult = mMarketPlaceParser.Parse(tmpResult);
                listPurchase.AddRange(tmpParsedResult);
            });
            return listPurchase;
        }

        public ZakupkiUploader(ZakupkiParameters parameters, IUrlBuilder urlBuilder, IClient client, IMarketplaceParser marketPlaceParser, IMaxNumberPageParser maxNumberPageParser)
        {
            mParameters = parameters;
            mUrlBuilder = urlBuilder;
            mClient = client;
            mMarketPlaceParser = marketPlaceParser;
            mMaxNumberPageParser = maxNumberPageParser;
        }
    }
}
