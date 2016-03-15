using System.Collections.Generic;
using System.Linq;
using MarketplaceDB;
using Ninject;
using ParseZakupki.Entity;
using ParseZakupki.Module;

namespace ParseZakupki
{
    class Program
    {
        //private static ParametersDb LoadParameters()
        //{
        //    ParametersDb parameters;
        //    using (var dbContext = new MarketplaceContext())
        //        parameters = dbContext.Parameters.ToArray().Last();
        //    return parameters;
        //}

        //private static IReadOnlyCollection<Marketplace> Upload(CommonModule module)
        //{
        //    var kernel = new StandardKernel(module);
        //    var uploader = kernel.Get<LotUpload.LotUploaderJs>();
        //    var result = uploader.Upload();
        //    return result;
        //}

        //private static void SaveDataToDb(IReadOnlyCollection<Marketplace> data)
        //{
        //    using (var dbContext = new MarketplaceContext())
        //    {
        //        dbContext.Purchase.AddRange(data);
        //        dbContext.SaveChanges();
        //    }
        //}

        static void Main(string[] args)
        {
            //var module = new SberModule(LoadParameters());

            //var result = Upload(module);
            //SaveDataToDb(result);

            using (var entity = new MarketplaceDBEntities())
            {
                entity.Marketplace.Add(new Marketplace()
                {
                    Code = "test",
                    Cost = "test",
                    Customer = "test",
                    DateCreated = "test",
                    DateFilling = "test",
                    Description = "test",
                    SiteId = "test",
                    SourceLink = "test"
                });
                entity.SaveChanges();
            }
        }
    }
}
