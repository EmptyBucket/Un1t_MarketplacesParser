using System;
using ParseZakupki.Entity;
using ParseZakupki.Module;
using ParseZakupki.Parameter;
using ParseZakupki.Parser;
using ParseZakupki.Parser.ZakupkiParser;
using ParseZakupki.Parser.ZakupkiParser.NodeParser;

namespace ParseZakupki
{
    public class ZakupkiModule : CommonModule
    {
        private ParametersDb mParameters;

        public ZakupkiModule(ParametersDb parameters)
        {
            mParameters = parameters;
        }

        public override void Load()
        {
            base.Load();

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
            Bind<IMaxNumberPageParser>().To<ZakupkiMaxNumberPageParser>();
            Bind<ZakupkiParameters>().ToSelf()
                .WithPropertyValue("CostFrom", mParameters.CostFrom)
                .WithPropertyValue("CostTo", mParameters.CostTo)
                .WithPropertyValue("PublishDateFrom", mParameters.PublishDateFrom)
                .WithPropertyValue("PublishDateTo", mParameters.PublishDateTo);

                //.WithPropertyValue("PublishDateFrom", DateTime.Now.AddDays(-7))
                //.WithPropertyValue("PublishDateTo", DateTime.Now);
        }
    }
}
