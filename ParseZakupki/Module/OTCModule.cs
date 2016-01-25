using System;
using ParseZakupki.Entity;
using ParseZakupki.Parameter.OTCParameter;
using ParseZakupki.Parser;
using ParseZakupki.Parser.OTCParser;
using ParseZakupki.Parser.OTCParser.NodeParser;
using ParseZakupki.UrlBuilder.ZakupkiUrlBuilder;

namespace ParseZakupki
{
    public class OTCModule : Ninject.Modules.NinjectModule
    {
        private readonly ParametersDb mParameters;

        public override void Load()
        {
            Bind<IParameters>().To<OTCParameters>();
            Bind<IParameterType>().To<OTCParametersType>();
            Bind<IUrlBuilder>().To<OTCUrlBuilder>();
            Bind<ILotsSpliter>().To<OTCLotsSpliter>();
            Bind<INodeLotParser>().To<OTCNodeLotParser>()
                .WithConstructorArgument("domain", new Uri("http://tender.otc.ru"))
                .WithConstructorArgument("dateCreatedParser", new OTCDateCreatedParser())
                .WithConstructorArgument("costParser", new OTCCostParser())
                .WithConstructorArgument("customerParser", new OTCCustomerParser())
                .WithConstructorArgument("descParser", new OTCDescriptionParser())
                .WithConstructorArgument("idParser", new OTCIdParser())
                .WithConstructorArgument("dateFiilingParser", new OTCDateFillingParser())
                .WithConstructorArgument("codeParser", new OTCCodeParser())
                .WithConstructorArgument("sourceLinkParser", new OTCSourceLinkParser());
            Bind<IMaxNumberPageParser>().To<OTCMaxNumberPageParser>();
            Bind<OTCParameters>().ToSelf()
                .WithPropertyValue("CostFrom", mParameters.CostFrom)
                .WithPropertyValue("CostTo", mParameters.CostTo)
                .WithPropertyValue("PublishDateFrom", mParameters.PublishDateFrom)
                .WithPropertyValue("PublishDateTo", mParameters.PublishDateTo);

                //.WithPropertyValue("PublishDateFrom", DateTime.Now.AddDays(-7))
                //.WithPropertyValue("PublishDateTo", DateTime.Now);
        }

        public OTCModule(ParametersDb parameters)
        {
            mParameters = parameters;
        }
    }
}
