using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParseZakupki.Entity
{
    [Table("OTCParameters")]
    public class OTCParametersDb
    {
        [Key]
        public int id { get; set; }
        public int RecordsPerPage { get; set; }
        public long CostFrom { get; set; }
        public long CostTo { get; set; }
        public string PublishDateFrom { get; set; }
        public string PublishDateTo { get; set; }
        public bool Fz44 { get; set; }
        public bool Fz223 { get; set; }
        public bool Commercial { get; set; }
    }
}
