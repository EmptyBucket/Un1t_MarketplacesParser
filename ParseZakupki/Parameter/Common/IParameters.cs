using System;

namespace ParseZakupki.Parameter.Common
{
    public interface IParameters
    {
        long CostFrom { get; set; }
        long CostTo { get; set; }
        DateTime PublishDateFrom { get; set; }
        DateTime PublishDateTo { get; set; }
    }
}
