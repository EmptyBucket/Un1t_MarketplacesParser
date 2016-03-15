using System;
using ParseZakupki.Entity;
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
        private readonly ParametersDb _parameters;

        public override void Load()
        {
            base.Load();

            Bind<ILotUploader>().To<LotUploader>();
            Bind<IPageParameters>().To<OtcParameters>()
                .WithPropertyValue("CostFrom", _parameters.CostFrom)
                .WithPropertyValue("CostTo", _parameters.CostTo)
                .WithPropertyValue("PublishDateFrom", _parameters.PublishDateFrom)
                .WithPropertyValue("PublishDateTo", _parameters.PublishDateTo);
            Bind<IParameterType>().To<OtcParametersType>();
            Bind<IMaxNumberPageParser>().To<OtcMaxNumberPageParser>();
            Bind<IUrlBuilder>().To<OtcUrlBuilder>();
            Bind<ILotsSpliter>().To<OtcLotsSpliter>();
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

        public OtcModule(ParametersDb parameters)
        {
            _parameters = parameters;
        }
    }
}
