using System.Collections.Generic;
using System.Linq;
using Ninject;
using ParseZakupki.Entity;
using ParseZakupki.Module;

namespace ParseZakupki
{
    class Program
    {
        private static ParametersDb LoadParameters()
        {
            ParametersDb parameters;
            using (var dbContext = new PurchaseInformationContext())
                parameters = dbContext.Parameters.ToArray().Last();
            return parameters;
        }

        private static IReadOnlyCollection<PurchaseInformation> Upload(CommonModule module)
        {
            var kernel = new StandardKernel(module);
            var uploader = kernel.Get<LotUpload.LotUploaderJs>();
            var result = uploader.Upload();
            return result;
        }

        private static void SaveDataToDb(IReadOnlyCollection<PurchaseInformation> data)
        {
            using (var dbContext = new PurchaseInformationContext())
            {
                dbContext.Purchase.AddRange(data);
                dbContext.SaveChanges();
            }
        }

        static void Main(string[] args)
        {
            var module = new SberModule(LoadParameters());

            var result = Upload(module);
            SaveDataToDb(result);
        }
    }
}
