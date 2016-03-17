using System;
using System.Collections.Generic;
using System.Linq;

namespace MarketplaceLocalDB.Repository
{
    public class LotsRepository : IDisposable
    {
        private readonly MarketplacesEntities _marketplaceContext;

        public LotsRepository()
        {
            _marketplaceContext = new MarketplacesEntities();
        }

        public void Dispose() => _marketplaceContext.Dispose();

        public IQueryable<Lot> Get() => _marketplaceContext.Lot.AsNoTracking();

        public IQueryable<Lot> Get(string site = null, string customer = null, string dateCreated = null,
            string cost = null, string description = null, string dateStart = null, string dateEnd = null,
            string code = null)
        {
            IQueryable<Lot> result = _marketplaceContext.Lot
                .AsNoTracking()
                .OrderBy(m => m.Id);
            if (!string.IsNullOrEmpty(customer))
                result = result.Where(m => m.Customer.ToLower().Contains(customer.ToLower()));
            if (!string.IsNullOrEmpty(dateCreated))
                result = result.Where(m => m.DateCreated == dateCreated);
            if (!string.IsNullOrEmpty(cost))
                result = result.Where(m => m.Cost == cost);
            if (!string.IsNullOrEmpty(description))
                result = result.Where(m => m.Description.ToLower().Contains(description.ToLower()));
            if (!string.IsNullOrEmpty(dateStart))
                result = result.Where(m => m.DateStart == dateStart);
            if (!string.IsNullOrEmpty(dateEnd))
                result = result.Where(m => m.DateEnd == dateEnd);
            if (!string.IsNullOrEmpty(code))
                result = result.Where(m => m.Code.ToLower().Contains(code.ToLower()));
            if (!string.IsNullOrEmpty(site))
                result = result.Where(m => m.Marketplace1.Any(item => item.InformationOnMarketplace.Name.ToLower().Contains(site.ToLower())));
            return result;
        }

        public void Clear()
        {
            var dbSet = _marketplaceContext.Lot.ToArray();
            _marketplaceContext.Lot.RemoveRange(dbSet);
            _marketplaceContext.SaveChanges();
        }

        public void AddRange(IEnumerable<Lot> lot)
        {
            _marketplaceContext.Lot.AddRange(lot);
            _marketplaceContext.SaveChanges();
        }

        public int Count() => _marketplaceContext.Lot.Count();
    }
}