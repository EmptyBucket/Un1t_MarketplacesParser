namespace ParseZakupki.Parameter.Common
{
    public interface IPageParameters : IParameters
    {
        int PageNumber { get; set; }
        int RecordsPerPage { get; set; }
    }
}