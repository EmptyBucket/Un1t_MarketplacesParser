using System;
using MarketplaceLocalDB;
using ParseZakupki.LotUpload;
using ParseZakupki.Parameter.Common;
using ParseZakupki.Parameter.OTCParameter;
using ParseZakupki.Parser.Common;
using ParseZakupki.Parser.OTCParser;
using ParseZakupki.Parser.OTCParser.NodeParser;
using ParseZakupki.UrlBuilder;

namespace ParseZakupki.Module
{
    public class OtcModule : CommonModule
    {
        private readonly ParseParameter _parameter;

        public override void Load()
        {
            base.Load();

            Bind<ILotUploader>().To<LotUploader>();
            Bind<IPageParameter>().To<OtcParameter>()
                .WithPropertyValue("CostFrom", _parameter.CostFrom)
                .WithPropertyValue("CostTo", _parameter.CostTo)
                .WithPropertyValue("PublishDateFrom", _parameter.PublishDateFrom)
                .WithPropertyValue("PublishDateTo", _parameter.PublishDateTo);
            Bind<IParameterType>().To<OtcParameterType>();
            Bind<IMaxNumberPageParser>().To<OtcMaxNumberPageParser>();
            Bind<IUrlBuilder>().To<OtcUrlBuilder>();
            Bind<ILotSpliter>().To<OtcLotSpliter>();
            Bind<INodeLotParser>().To<OtcNodeLotParser>()
                .WithConstructorArgument("domain", new Uri("http://tender.otc.ru"))
                .WithConstructorArgument("dateCreatedParser", new OtcDateCreatedParser())
                .WithConstructorArgument("costParser", new OtcCostParser())
                .WithConstructorArgument("customerParser", new OtcCustomerParser())
                .WithConstructorArgument("descParser", new OtcDescriptionParser())
                .WithConstructorArgument("idParser", new OtcIdParser())
                .WithConstructorArgument("dateFillingParser", new OtcDateFillingParser())
                .WithConstructorArgument("codeParser", new OtcCodeParser())
                .WithConstructorArgument("sourceLinkParser", new OtcSourceLinkParser());
        }

        public OtcModule(ParseParameter parameter)
        {
            _parameter = parameter;
        }
    }
}
