using Bakery.Product.DomainApi.Port;
using Bakery.Product.Persistence.Adapter.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Bakery.Product.Domain
{
    public class ProductDomain<T> : IRequestProduct<T> where T : Bakery.Product.DomainApi.Model.Product
    {
        private readonly DbSet<T> table;

        public ApplicationDbContext _dbContext { get; }

        public ProductDomain(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            table = dbContext.Set<T>();
        }
        public T GetValue(int id)
        {
            return table.Find(id);
        }

        public List<T> GetValues()
        {
            return table.ToList();
        }

        public T AddValue(T value)
        {
            table.Add(value);
            _dbContext.SaveChanges();
            return value;
        }

        public T UpdateValue(T value)
        {
            table.Update(value);
            _dbContext.SaveChanges();
            return value;
        }
    }
}
