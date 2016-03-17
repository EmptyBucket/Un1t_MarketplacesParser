using System;
using MarketplaceLocalDB;
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
        private readonly ParseParameter _parameter;

        public ZakupkiModule(ParseParameter parameter)
        {
            _parameter = parameter;
        }

        public override void Load()
        {
            base.Load();

            Bind<ILotUploader>().To<LotUploader>();
            Bind<IPageParameter>().To<ZakupkiParameter>()
                .WithPropertyValue("CostFrom", _parameter.CostFrom)
                .WithPropertyValue("CostTo", _parameter.CostTo)
                .WithPropertyValue("PublishDateFrom", DateTime.Now.AddDays(-1))
                .WithPropertyValue("PublishDateFrom", _parameter.PublishDateFrom)
                .WithPropertyValue("PublishDateTo", _parameter.PublishDateTo);
            Bind<IUrlBuilder>().To<ZakupkiUrlBuilder>();
            Bind<IMaxNumberPageParser>().To<ZakupkiMaxNumberPageParser>();
            Bind<IParameterType>().To<ZakupkiParameterType>();
            Bind<ILotSpliter>().To<ZakupkiLotSpliter>();
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
