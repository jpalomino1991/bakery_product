using Bakery.Product.DomainApi.Port;
using Bakery.Product.Persistence.Adapter.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Bakery.Product.Domain
{
    public class DealDomain<T> : IRequestDeal<T> where T : class
    {
        private readonly DbSet<T> table;

        public DealDomain(ApplicationDbContext dbContext)
        {
            ApplicationDbContext _dbContext;
            _dbContext = dbContext;
            table = _dbContext.Set<T>();
        }
        public T GetDeal(int id)
        {
            return table.Find(id);
        }

        public List<T> GetDeals()
        {
            return table.ToList();
        }
    }
}
