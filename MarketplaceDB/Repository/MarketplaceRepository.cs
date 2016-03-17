using System;
using System.Collections.Generic;
using System.Linq;

namespace MarketplaceLocalDB.Repository
{
    public class MarketplaceRepository : IDisposable
    {
        private readonly MarketplacesEntities _marketplaceContext;

        public MarketplaceRepository()
        {
            _marketplaceContext = new MarketplacesEntities();
        }

        public void Dispose() => _marketplaceContext.Dispose();

        public IQueryable<Marketplace1> Get() => _marketplaceContext.Marketplace1;

        public void Insert(IEnumerable<Marketplace1> marketplaces)
        {
            _marketplaceContext.Marketplace1.AddRange(marketplaces);
            _marketplaceContext.SaveChanges();
        }

        public void Clear()
        {
            var dbSet = _marketplaceContext.Marketplace1.ToArray();
            _marketplaceContext.Marketplace1.RemoveRange(dbSet);
            _marketplaceContext.SaveChanges();
        }

        public int Count() => _marketplaceContext.Lot.Count();
    }
}