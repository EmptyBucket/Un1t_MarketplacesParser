using System;
using System.IO;
using ParseZakupki.Entity;

namespace ParseZakupki
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "TextFile1.txt"));

            //var parameters = new ZakupkiParameters();
            //parameters.RecordsPerPage = 10;
            //var urlBuilder = new ZakupkiUrlBuilder();
            //string url = urlBuilder.Build(parameters);
            //var client = new ZakupkiClient();
            //var result = client.GetResult(url);
            var zakupkiParser = new ZakupkiParser();
            var parseResult = zakupkiParser.Parse(result);
            using (var dbContext = new PurchaseContext())
            {
                dbContext.Purchase.AddRange(parseResult);
                dbContext.SaveChanges();
            }
        }
    }
}
