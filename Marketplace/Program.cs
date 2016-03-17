using System;
using System.Data.Entity.Validation;
using System.Linq;
using MarketplaceLocalDB;
using MarketplaceLocalDB.Repository;
using Ninject;
using Ninject.Modules;
using ParseZakupki.LotUpload;
using ParseZakupki.Module;

namespace ParseZakupki
{
    class Program
    {
        public static NinjectModule GetModule(string name)
        {
            var parameter = new ParameterRepostitory().Get().ToArray().Last();
            switch (name)
            {
                case "Закупки":
                    return new ZakupkiModule(parameter);
                case "OTC":
                    return new OtcModule(parameter);
                default:
                    throw new Exception("Not exist marketplace witch such name");
            }
        }

        static void Main(string[] args)
        {
            var currentMarketplaceName = "Закупки";
            var currentMarketplaceId = new InformationOnMarketplaceRepository().Get()
                .First(info => info.Name == currentMarketplaceName);

            var module = GetModule(currentMarketplaceName);
            var kernel = new StandardKernel(module);
            var lotUploader = kernel.Get<ILotUploader>();
            var lots = lotUploader.Upload();
            try
            {
                var marketplaces = lots.Select(lot => new Marketplace1 { InformationOnMarketplace = currentMarketplaceId, Lot = lot });
                using (var marketplaceRepository = new MarketplaceRepository())
                    marketplaceRepository.Insert(marketplaces);
            }
            catch (Exception e)
            {
                if (e is DbEntityValidationException)
                    foreach (var eve in ((DbEntityValidationException)e).EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
            }
        }
    }
}
