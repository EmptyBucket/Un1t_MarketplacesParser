using System;

namespace ParseZakupki.Parameter.Common
{
    public interface IParameter
    {
        double CostFrom { get; set; }
        double CostTo { get; set; }
        DateTime PublishDateFrom { get; set; }
        DateTime PublishDateTo { get; set; }
    }
}
