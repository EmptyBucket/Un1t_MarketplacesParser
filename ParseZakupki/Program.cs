using System.Linq;
using Ninject;
using ParseZakupki.Entity;

namespace ParseZakupki
{
    class Program
    {
        static void Main(string[] args)
        {
            ZakupkiParametersDb parameters;
            using (var dbContext = new PurchaseInformationContext())
                parameters = dbContext.Parameters.ToArray().Last();
            var kernel = new StandardKernel(new ZakupkiModule(parameters));
            var zakupkiParser = kernel.Get<LotUploader>();
            var result = zakupkiParser.Upload();
            using (var dbContext = new PurchaseInformationContext())
            {
                dbContext.Purchase.AddRange(result);
                dbContext.SaveChanges();
            }
        }
    }
}
