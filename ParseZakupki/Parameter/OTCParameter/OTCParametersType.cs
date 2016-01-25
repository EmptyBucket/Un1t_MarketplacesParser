namespace ParseZakupki.Parameter.OTCParameter
{
    public class OTCParametersType : IParameterType
    {
        public static OTCParametersType MinPrice = new OTCParametersType("SearchForm.MinPrice");
        public static OTCParametersType MaxPrice = new OTCParametersType("SearchForm.MaxPrice");
        public static OTCParametersType DatePublishedFrom = new OTCParametersType("SearchForm.DatePublishedFrom");
        public static OTCParametersType DatePublishedTo = new OTCParametersType("SearchForm.DatePublishedTo");
        public static OTCParametersType OrganizationLevels = new OTCParametersType("SearchForm.OrganizationLevels");
        public static OTCParametersType PageSize = new OTCParametersType("FilterData.PageSize");
        public static OTCParametersType PageIndex = new OTCParametersType("FilterData.PageIndex");

        public string Type { get; }

        private OTCParametersType(string parameterType)
        {
            Type = parameterType;
        }
    }
}
