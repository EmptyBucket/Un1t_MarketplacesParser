using System.Collections.Generic;

namespace ParseZakupki.UrlBuilder.ZakupkiUrlBuilder
{
    public class OTCUrlBuilder : IUrlBuilder
    {
        public const string Domain = "http://tender.otc.ru";

        public string Build(IReadOnlyDictionary<IParameterType, Parameter.Parameter> parameters)
        {
            string parametersStr = parameters.ToString();
            string url = $@"{Domain}http://tender.otc.ru/main/tr/?{parameters}&SearchForm.State=0&SearchForm.DocumentSearchEnabled=false&SearchForm.HasApplications=on&SearchForm.CurrencyCode=643&SearchForm.SectionIds=2&SearchForm.SectionIds=3&SearchForm.SectionIds=8&SearchForm.SectionIds=6&SearchForm.SectionIds=1&SearchForm.SectionIds=101&SearchForm.SectionIds=102&SearchForm.SectionIds=103&SearchForm.SectionIds=104&SearchForm.SectionIds=105&SearchForm.SectionIds=106&FilterData.SortingField=DatePublished&FilterData.SortingDirection=Desc&";
            return url;
        }
    }
}
