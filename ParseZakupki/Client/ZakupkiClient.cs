using System.IO;
using System.Net;
using ParseZakupki.Client;

namespace ParseZakupki
{
    public class ZakupkiClient : IClient
    {
        private const string Domain = "new.zakupki.gov.ru";

        private HttpWebRequest CreateRequest(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Host = Domain;
            request.KeepAlive = true;
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/47.0.2526.111 Safari/537.36";
            request.Referer = "http://new.zakupki.gov.ru/epz/order/extendedsearch/results.html?pageNumber=1&recordsPerPage=_500&priceFrom=0&priceTo=200000000000&publishDateFrom=21.01.2016&publishDateTo=21.01.2016&fz44=on&searchString=&openMode=USE_D";
            request.Headers.Add("Cache-Control", "max-age=0");
            request.Headers.Add("Upgrade-Insecure-Requests", "1");
            request.Headers.Add("Accept-Encoding", "gzip, deflate, sdch");
            request.Headers.Add("Accept-Language", "ru-RU,ru;q=0.8,en-US;q=0.6,en;q=0.4");
            return request;
        }

        public string GetResult(string url)
        {
            var request = CreateRequest(url);
            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            using (var streamReader = new StreamReader(stream))
                return streamReader.ReadToEnd();
        }
    }
}
