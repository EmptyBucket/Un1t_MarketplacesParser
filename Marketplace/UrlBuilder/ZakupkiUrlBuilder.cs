using ParseZakupki.Parameter.Common;

namespace ParseZakupki.UrlBuilder
{
    public class ZakupkiUrlBuilder : IUrlBuilder
    {
        public const string Domain = "http://new.zakupki.gov.ru";

        public string Build(IParameter parameter)
        {
            string parameterStr = parameter.ToString();
            string url = $@"{Domain}/epz/order/extendedsearch/results.html?{parameterStr}searchString=&openMode=USE_DEFAULT_PARAMS&sortDirection=false&showLotInfoHidden=false&orderNumber=&placingWaysList=&placingWaysList223=&currencyId=1&orderName=&participantName=&updateDateFrom=&updateDateTo=&customerTitle=&customerCode=&customerFz94id=&customerFz223id=&customerInn=&agencyTitle=&agencyCode=&agencyFz94id=&agencyFz223id=&agencyInn=&districts=&regions=&af=on&ca=on&deliveryAddress=&sortBy=RELEVANCE";
            return url;
        }
    }
}
