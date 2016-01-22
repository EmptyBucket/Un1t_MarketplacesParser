using System.Data.Entity;

namespace ParseZakupki.Entity
{
    public class PurchaseContext : DbContext
    {
        public DbSet<PurchaseInformation> Purchase { get; set; }
    }
}
