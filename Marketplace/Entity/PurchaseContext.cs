using System.Data.Entity;

namespace ParseZakupki.Entity
{
    public class MarketplaceContext : DbContext
    {
        public DbSet<ParametersDb> Parameters { get; set; }
    }
}
