using System;
using ParseZakupki.Parameter.Common;

namespace ParseZakupki.Parameter.SberParameter
{
    public class SberParameters : IParameters
    {
        public long CostFrom { get; set; }
        public long CostTo { get; set; }
        public DateTime PublishDateFrom { get; set; }
        public DateTime PublishDateTo { get; set; }
    }
}