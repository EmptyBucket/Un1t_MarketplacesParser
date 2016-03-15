using ParseZakupki.Parameter.Common;

namespace ParseZakupki.Parameter.OTCParameter
{
    public class OtcParametersType : IParameterType
    {
        public static OtcParametersType MinPrice = new OtcParametersType("SearchForm.MinPrice");
        public static OtcParametersType MaxPrice = new OtcParametersType("SearchForm.MaxPrice");
        public static OtcParametersType DatePublishedFrom = new OtcParametersType("SearchForm.DatePublishedFrom");
        public static OtcParametersType DatePublishedTo = new OtcParametersType("SearchForm.DatePublishedTo");
        public static OtcParametersType OrganizationLevels = new OtcParametersType("SearchForm.OrganizationLevels");
        public static OtcParametersType PageSize = new OtcParametersType("FilterData.PageSize");
        public static OtcParametersType PageIndex = new OtcParametersType("FilterData.PageIndex");

        public string Type { get; }

        private OtcParametersType(string parameterType)
        {
            Type = parameterType;
        }
    }
}
