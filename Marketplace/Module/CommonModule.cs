using ParseZakupki.Client;
using ParseZakupki.Parser.Common;

namespace ParseZakupki.Module
{
    public class CommonModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IClient>().To<Client.Client>();
            Bind<IMarketplaceParser>().To<MarketplaceParser>();
        }
    }
}
