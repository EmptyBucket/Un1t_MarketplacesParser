using System;
using MarketplaceLocalDB;
using ParseZakupki.LotUpload;
using ParseZakupki.Parameter.Common;
using ParseZakupki.Parameter.SberParameter;
using ParseZakupki.Parser.Common;
using ParseZakupki.Parser.SberParser;
using ParseZakupki.Parser.SberParser.NodeParser;
using ParseZakupki.UrlBuilder;

namespace ParseZakupki.Module
{
    public class SberModule : CommonModule
    {
        private readonly ParseParameter _parameter;

        public override void Load()
        {
            base.Load();
            Bind<ILotUploader>().To<LotUploaderJs>();
            Bind<IParameter>().To<SberParameter>()
                .WithConstructorArgument("CostFrom", _parameter.CostFrom)
                .WithConstructorArgument("CostTo", _parameter.CostTo)
                .WithConstructorArgument("PublishDateFrom", _parameter.PublishDateFrom)
                .WithConstructorArgument("PublishDateTo", _parameter.PublishDateTo);
            Bind<IUrlBuilder>().To<SberUrlBuilder>();
            Bind<ILotSpliter>().To<SberLotpliter>();
            Bind<INodeLotParser>().To<SberNodeLotParser>()
                .WithConstructorArgument("domain", new Uri("http://sberbank-ast.ru"))
                .WithConstructorArgument("dateCreatedParser", new SberDateCreatedParser())
                .WithConstructorArgument("costParser", new SberCostParser())
                .WithConstructorArgument("customerParser", new SberCustomerParser())
                .WithConstructorArgument("descParser", new SberDescriptionParser())
                .WithConstructorArgument("idParser", new SberIdParser())
                .WithConstructorArgument("dateFillingParser", new SberDateFillingParser())
                .WithConstructorArgument("codeParser", new SberCodeParser())
                .WithConstructorArgument("sourceLinkParser", new SberSourceLinkParser());
        }

        public SberModule(ParseParameter parameter)
        {
            _parameter = parameter;
        }
    }
}