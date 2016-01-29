using System;
using ParseZakupki.Entity;
using ParseZakupki.LotUpload;
using ParseZakupki.Parameter.Common;
using ParseZakupki.Parameter.ZakupkiParameter;
using ParseZakupki.Parser.Common;
using ParseZakupki.Parser.ZakupkiParser;
using ParseZakupki.Parser.ZakupkiParser.NodeParser;
using ParseZakupki.UrlBuilder;

namespace ParseZakupki.Module
{
    public class ZakupkiModule : CommonModule
    {
        private readonly ParametersDb _parameters;

        public ZakupkiModule(ParametersDb parameters)
        {
            _parameters = parameters;
        }

        public override void Load()
        {
            base.Load();

            Bind<ILotUploader>().To<LotUploader>();
            Bind<IPageParameters>().To<ZakupkiParameters>()
                .WithPropertyValue("CostFrom", _parameters.CostFrom)
                .WithPropertyValue("CostTo", _parameters.CostTo)
                .WithPropertyValue("PublishDateFrom", DateTime.Now.AddDays(-1))
                .WithPropertyValue("PublishDateFrom", _parameters.PublishDateFrom)
                .WithPropertyValue("PublishDateTo", _parameters.PublishDateTo);
            Bind<IUrlBuilder>().To<ZakupkiUrlBuilder>();
            Bind<IMaxNumberPageParser>().To<ZakupkiMaxNumberPageParser>();
            Bind<IParameterType>().To<ZakupkiParameterType>();
            Bind<ILotsSpliter>().To<ZakupkiLotsSpliter>();
            Bind<INodeLotParser>().To<ZakupkiNodeLotParser>()
                .WithConstructorArgument("domain", new Uri("http://new.zakupki.gov.ru/"))
                .WithConstructorArgument("dateCreatedParser", new ZakupkiDateCreatedParser())
                .WithConstructorArgument("costParser", new ZakupkiCostParser())
                .WithConstructorArgument("customerParser", new ZakupkiCustomerParser())
                .WithConstructorArgument("descParser", new ZakupkiDescriptionParser())
                .WithConstructorArgument("idParser", new ZakupkiIdParser())
                .WithConstructorArgument("dateFillingParser", new ZakupkiDateFillingParser())
                .WithConstructorArgument("codeParser", new ZakupkiCodeParser())
                .WithConstructorArgument("sourceLinkParser", new ZakupkiSourceLinkParser());
        }
    }
}
