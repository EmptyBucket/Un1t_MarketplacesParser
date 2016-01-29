using ParseZakupki.Parameter.Common;

namespace ParseZakupki.UrlBuilder
{
    public class SberUrlBuilder : IUrlBuilder
    {
        public string Build(IParameters parameters) => "http://sberbank-ast.ru/purchaseList.aspx";
    }
}