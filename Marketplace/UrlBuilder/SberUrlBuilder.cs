using ParseZakupki.Parameter.Common;

namespace ParseZakupki.UrlBuilder
{
    public class SberUrlBuilder : IUrlBuilder
    {
        public string Build(IParameter parameter) => "http://sberbank-ast.ru/purchaseList.aspx";
    }
}