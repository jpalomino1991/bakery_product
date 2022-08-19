using Bakery.Product.DomainApi.Services;
using Bakery.Product.Persistence.Adapter.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Bakery.Product.Persistence.Adapter
{
    public static class PersistenceExtensions
    {
        public static void AddPersistence(this IServiceCollection serviceCollection, AppSettings appSettings)
        {
            serviceCollection.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(appSettings.SqlAzureProduct.ConnectionString));
        }
    }
}
