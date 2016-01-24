using System;
using ParseZakupki.Entity;
using ParseZakupki.Parameter;
using ParseZakupki.Parser;

namespace ParseZakupki
{
    public class Module : Ninject.Modules.NinjectModule
    {
        private ZakupkiParametersDb mParameters;

        public Module(ZakupkiParametersDb parameters)
        {
            this.mParameters = parameters;
        }

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
                .WithPropertyValue("RecordsPerPage", mParameters.RecordsPerPage)
                .WithPropertyValue("CostFrom", mParameters.CostFrom)
                .WithPropertyValue("CostTo", mParameters.CostTo)
                .WithPropertyValue("PublishDateFrom", DateTime.Parse(mParameters.PublishDateFrom))
                .WithPropertyValue("PublishDateTo", DateTime.Parse(mParameters.PublishDateTo))
                .WithPropertyValue("Fz44", mParameters.Fz44)
                .WithPropertyValue("Fz94", mParameters.Fz94)
                .WithPropertyValue("Fz223", mParameters.Fz223);
        }
    }
}
