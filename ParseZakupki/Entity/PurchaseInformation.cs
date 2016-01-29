using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParseZakupki.Entity
{
    [Table("PurchaseInformation")]
    public class PurchaseInformation
    {
        [Key]
        public int Id { get; set; }
        public string Customer { get; set; }
        public string DateCreated { get; set; }
        public string Cost { get; set; }
        public string Description { get; set; }
        public string SiteId { get; set; }
        public string DateFilling { get; set; }
        public string SourceLink { get; set; }
        public string Code { get; set; }
    }
}
