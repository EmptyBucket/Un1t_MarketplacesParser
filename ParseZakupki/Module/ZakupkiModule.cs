using System;
using ParseZakupki.Entity;
using ParseZakupki.Parameter;
using ParseZakupki.Parser;
using ParseZakupki.Parser.ZakupkiParser;
using ParseZakupki.Parser.ZakupkiParser.NodeParser;

namespace ParseZakupki
{
    public class ZakupkiModule : Ninject.Modules.NinjectModule
    {
        private ZakupkiParametersDb mParameters;

        public ZakupkiModule(ZakupkiParametersDb parameters)
        {
            mParameters = parameters;
        }

        public override void Load()
        {
            Bind<IClient>().To<Client>();
            Bind<IParameters>().To<ZakupkiParameters>();
            Bind<IParameterType>().To<ZakupkiParameterType>();
            Bind<IUrlBuilder>().To<ZakupkiUrlBuilder>();
            Bind<ILotsSpliter>().To<ZakupkiLotsSpliter>();
            Bind<INodeLotParser>().To<ZakupkiNodeLotParser>()
                .WithConstructorArgument("domain", new Uri("http://new.zakupki.gov.ru/"))
                .WithConstructorArgument("dateCreatedParser", new ZakupkiDateCreatedParser())
                .WithConstructorArgument("costParser", new ZakupkiCostParser())
                .WithConstructorArgument("customerParser", new ZakupkiCustomerParser())
                .WithConstructorArgument("descParser", new ZakupkiDescriptionParser())
                .WithConstructorArgument("idParser", new ZakupkiIdParser())
                .WithConstructorArgument("dateFiilingParser", new ZakupkiDateFillingParser())
                .WithConstructorArgument("codeParser", new ZakupkiCodeParser())
                .WithConstructorArgument("sourceLinkParser", new ZakupkiSourceLinkParser());
            Bind<IMarketplaceParser>().To<MarketplaceParser>();
            Bind<IMaxNumberPageParser>().To<ZakupkiMaxNumberPageParser>();
            Bind<ZakupkiParameters>().ToSelf()
                .WithPropertyValue("RecordsPerPage", mParameters.RecordsPerPage)
                .WithPropertyValue("CostFrom", mParameters.CostFrom)
                .WithPropertyValue("CostTo", mParameters.CostTo)
                .WithPropertyValue("PublishDateFrom", DateTime.Parse(mParameters.PublishDateFrom))
                .WithPropertyValue("PublishDateTo", DateTime.Parse(mParameters.PublishDateTo))
                .WithPropertyValue("Fz44", mParameters.Fz44)
                .WithPropertyValue("Fz94", mParameters.Fz94)
                .WithPropertyValue("Fz223", mParameters.Fz223)

                .WithPropertyValue("PublishDateFrom", DateTime.Now.AddDays(-7))
                .WithPropertyValue("PublishDateTo", DateTime.Now);
        }
    }
}
