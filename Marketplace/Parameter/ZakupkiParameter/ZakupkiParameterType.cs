using ParseZakupki.Parameter.Common;

namespace ParseZakupki.Parameter.ZakupkiParameter
{
    public struct ZakupkiParameterType : IParameterType
    {
        public static ZakupkiParameterType PageNumber = new ZakupkiParameterType("pageNumber");
        public static ZakupkiParameterType RecordsPerPage = new ZakupkiParameterType("recordsPerPage");
        public static ZakupkiParameterType PriceFrom = new ZakupkiParameterType("priceFrom");
        public static ZakupkiParameterType PriceTo = new ZakupkiParameterType("priceTo");
        public static ZakupkiParameterType PublishDateFrom = new ZakupkiParameterType("publishDateFrom");
        public static ZakupkiParameterType PublishDateTo = new ZakupkiParameterType("publishDateTo");
        public static ZakupkiParameterType Fz44 = new ZakupkiParameterType("fz44");
        public static ZakupkiParameterType Fz223 = new ZakupkiParameterType("fz223");
        public static ZakupkiParameterType Fz94 = new ZakupkiParameterType("fz94");

        public string Type { get; }

        private ZakupkiParameterType(string paremeterType)
        {
            Type = paremeterType;
        }
    }
}
