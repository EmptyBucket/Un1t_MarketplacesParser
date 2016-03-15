using System;
using ParseZakupki.Entity;
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
        private readonly ParametersDb _parameters;

        public override void Load()
        {
            base.Load();
            Bind<ILotUploader>().To<LotUploaderJs>();
            Bind<IParameters>().To<SberParameters>()
                .WithConstructorArgument("CostFrom", _parameters.CostFrom)
                .WithConstructorArgument("CostTo", _parameters.CostTo)
                .WithConstructorArgument("PublishDateFrom", _parameters.PublishDateFrom)
                .WithConstructorArgument("PublishDateTo", _parameters.PublishDateTo);
            Bind<IUrlBuilder>().To<SberUrlBuilder>();
            Bind<ILotsSpliter>().To<SberLotSpliter>();
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

        public SberModule(ParametersDb parameters)
        {
            _parameters = parameters;
        }
    }
}