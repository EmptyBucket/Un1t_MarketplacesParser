using System;
using System.Collections.Generic;

namespace ParseZakupki
{
    public interface IParameters : IReadOnlyDictionary<IParameterType, Parameter.Parameter>
    {
        int PageNumber { get; set; }
        int RecordsPerPage { get; set; }
        long CostFrom { get; set; }
        long CostTo { get; set; }
        DateTime PublishDateFrom { get; set; }
        DateTime PublishDateTo { get; set; }
    }
}
