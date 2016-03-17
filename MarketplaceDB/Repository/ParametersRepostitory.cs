using System;
using System.Linq;

namespace MarketplaceLocalDB.Repository
{
    public class ParameterRepostitory : IDisposable
    {
        private readonly MarketplacesEntities _marketplaceContext;

        public ParameterRepostitory()
        {
            _marketplaceContext = new MarketplacesEntities();
        }

        public void Dispose() => _marketplaceContext.Dispose();

        public IQueryable<ParseParameter> Get() => _marketplaceContext.ParseParameter;

        public int Count() => _marketplaceContext.Lot.Count();
    }
}