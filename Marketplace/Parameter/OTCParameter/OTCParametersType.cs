using ParseZakupki.Parameter.Common;

namespace ParseZakupki.Parameter.OTCParameter
{
    public class OtcParameterType : IParameterType
    {
        public static OtcParameterType MinPrice = new OtcParameterType("SearchForm.MinPrice");
        public static OtcParameterType MaxPrice = new OtcParameterType("SearchForm.MaxPrice");
        public static OtcParameterType DatePublishedFrom = new OtcParameterType("SearchForm.DatePublishedFrom");
        public static OtcParameterType DatePublishedTo = new OtcParameterType("SearchForm.DatePublishedTo");
        public static OtcParameterType OrganizationLevels = new OtcParameterType("SearchForm.OrganizationLevels");
        public static OtcParameterType PageSize = new OtcParameterType("FilterData.PageSize");
        public static OtcParameterType PageIndex = new OtcParameterType("FilterData.PageIndex");

        public string Type { get; }

        private OtcParameterType(string parameterType)
        {
            Type = parameterType;
        }
    }
}
