using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParseZakupki.Entity
{
    [Table("Parameters")]
    public class ParametersDb
    {
        [Key]
        public int Id { get; set; }
        public long CostFrom { get; set; }
        public long CostTo { get; set; }
        public DateTime PublishDateFrom { get; set; }
        public DateTime PublishDateTo { get; set; }
    }
}
