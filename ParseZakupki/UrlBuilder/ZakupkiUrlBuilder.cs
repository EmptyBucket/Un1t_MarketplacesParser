using System.Collections.Generic;
using ParseZakupki.Parameter;

namespace ParseZakupki
{
    public class ZakupkiUrlBuilder : IUrlBuilder<ZakupkiParameterType, ZakupkiParameter>
    {
        public const string Domain = "http://new.zakupki.gov.ru";

        public string Build(IReadOnlyDictionary<ZakupkiParameterType, ZakupkiParameter> parameters)
        {
            string parametersStr = parameters.ToString();
            string url = $@"{Domain}/epz/order/extendedsearch/results.html?{parametersStr}searchString=&openMode=USE_DEFAULT_PARAMS&sortDirection=false&showLotsInfoHidden=false&orderNumber=&placingWaysList=&placingWaysList223=&currencyId=1&orderName=&participantName=&updateDateFrom=&updateDateTo=&customerTitle=&customerCode=&customerFz94id=&customerFz223id=&customerInn=&agencyTitle=&agencyCode=&agencyFz94id=&agencyFz223id=&agencyInn=&districts=&regions=&af=on&ca=on&deliveryAddress=&sortBy=RELEVANCE";
            return url;
        }
    }
}
