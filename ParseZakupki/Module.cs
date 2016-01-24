using System;
using ParseZakupki.Parameter;
using ParseZakupki.Parser;

namespace ParseZakupki
{
    public class Module : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IClient>().To<Client>();
            Bind<IParameterType>().To<ZakupkiParameterType>();
            Bind<IParameter>().To<ZakupkiParameter>();
            Bind<IMarketplaceParser>().To<ZakupkiMarketplaceParser>();
            Bind<IUrlBuilder>().To(typeof(ZakupkiUrlBuilder));
            Bind<INodeContestParser>().To<NodeContestParser>()
                .WithConstructorArgument("createdParser", new ZakupkiCreatedParser())
                .WithConstructorArgument("updatedParser", new ZakupkiUpdatedParser())
                .WithConstructorArgument("costParser", new ZakupkiCostParser())
                .WithConstructorArgument("customerParser", new ZakupkiCustomerParser())
                .WithConstructorArgument("descParser", new ZakupkiDescriptionParser())
                .WithConstructorArgument("idParser", new ZakupkiIdParser());
            Bind<IMaxNumberPageParser>().To<ZakupkiMaxNumberPageParser>();
            Bind<ZakupkiParameters>().ToSelf()
                .WithPropertyValue("PublishDateFrom", new DateTime(2015, 11, 1))
                .WithPropertyValue("CostFrom", 100000000L);
        }
    }
}
