using System;
using System.Linq;

namespace MarketplaceLocalDB.Repository
{
    public class InformationOnMarketplaceRepository : IDisposable
    {
        private readonly MarketplacesEntities _marketplaceContext;

        public InformationOnMarketplaceRepository()
        {
            _marketplaceContext = new MarketplacesEntities();
        }

        public void Dispose() => _marketplaceContext.Dispose();

        public IQueryable<InformationOnMarketplace> Get() => _marketplaceContext.InformationOnMarketplace;

        public int Count() => _marketplaceContext.Lot.Count();

        public void Clear()
        {
            var dbSet = _marketplaceContext.InformationOnMarketplace.ToArray();
            _marketplaceContext.InformationOnMarketplace.RemoveRange(dbSet);
            _marketplaceContext.SaveChanges();
        }

        public void Remove(InformationOnMarketplace info) => _marketplaceContext.InformationOnMarketplace.Remove(info);
    }
}