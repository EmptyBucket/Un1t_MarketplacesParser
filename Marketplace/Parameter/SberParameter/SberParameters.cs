using System;
using ParseZakupki.Parameter.Common;

namespace ParseZakupki.Parameter.SberParameter
{
    public class SberParameter : IParameter
    {
        public double CostFrom { get; set; }
        public double CostTo { get; set; }
        public DateTime PublishDateFrom { get; set; }
        public DateTime PublishDateTo { get; set; }
    }
}