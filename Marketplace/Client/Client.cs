using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace ParseZakupki.Client
{
    public class Client : IClient
    {
        private HttpWebRequest CreateRequest(Uri url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Host = url.Host;
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/47.0.2526.111 Safari/537.36";
            request.Headers.Add("Cache-Control", "max-age=0");
            request.Headers.Add("Upgrade-Insecure-Requests", "1");
            request.Headers.Add("Accept-Encoding", "gzip, deflate, sdch");
            request.Headers.Add("Accept-Language", "ru-RU,ru;q=0.8,en-US;q=0.6,en;q=0.4");
            return request;
        }

        public HttpWebRequest CreateRequest(string url) => CreateRequest(new Uri(url));

        public string GetResult(Uri url)
        {
            var request = CreateRequest(url);
            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
                if (stream != null)
                    using (var streamReader = new StreamReader(stream))
                        return streamReader.ReadToEnd();
                else
                    return string.Empty;
        }

        public async Task<string> GetResultAsync(Uri url)
        {
            var request = CreateRequest(url);
            using (var response = await request.GetResponseAsync())
            using (var stream = response.GetResponseStream())
                if (stream != null)
                    using (var streamReader = new StreamReader(stream))
                        return await streamReader.ReadToEndAsync();
                else
                    return string.Empty;
        }
    }
}
