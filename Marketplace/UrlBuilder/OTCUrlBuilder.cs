using ParseZakupki.Parameter.Common;

namespace ParseZakupki.UrlBuilder
{
    public class OtcUrlBuilder : IUrlBuilder
    {
        public const string Domain = "http://tender.otc.ru";

        public string Build(IParameter parameter)
        {
            string url = $@"{Domain}/main/tr/?{parameter}&SearchForm.State=0&SearchForm.DocumentSearchEnabled=false&SearchForm.HasApplications=on&SearchForm.CurrencyCode=643&SearchForm.SectionIds=2&SearchForm.SectionIds=3&SearchForm.SectionIds=8&SearchForm.SectionIds=6&SearchForm.SectionIds=1&SearchForm.SectionIds=101&SearchForm.SectionIds=102&SearchForm.SectionIds=103&SearchForm.SectionIds=104&SearchForm.SectionIds=105&SearchForm.SectionIds=106&FilterData.SortingField=DatePublished&FilterData.SortingDirection=Desc&";
            return url;
        }
    }
}
