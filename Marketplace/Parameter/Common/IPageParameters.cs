namespace ParseZakupki.Parameter.Common
{
    public interface IPageParameter : IParameter
    {
        int PageNumber { get; set; }
        int RecordsPerPage { get; set; }
    }
}