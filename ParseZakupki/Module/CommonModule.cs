using ParseZakupki.Parser;

namespace ParseZakupki.Module
{
    public class CommonModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IClient>().To<Client>();
            Bind<IMarketplaceParser>().To<MarketplaceParser>();
        }
    }
}
