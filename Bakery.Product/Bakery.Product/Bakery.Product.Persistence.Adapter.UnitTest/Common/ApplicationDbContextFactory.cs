using Bakery.Product.DomainApi.Model;
using Bakery.Product.Persistence.Adapter.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using ProductModel = Bakery.Product.DomainApi.Model.Product;

namespace Bakery.Product.Persistence.Adapter.UnitTest.Common
{
    public static class ApplicationDbContextFactory
    {
        public static List<ProductModel> GetProducts()
        {
            return new List<ProductModel>()
            {
                new ProductModel(){Id=1, Name="ABC", Description="ABC deal 123", Price = 1000,},
                new ProductModel(){Id=2, Name="ABC", Description="ABC deal 456", Price = 2000,},
                new ProductModel(){Id=3, Name="ABC", Description="ABC deal 789", Price = 3000,},
            };
        }

        public static ApplicationDbContext Create()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new ApplicationDbContext(options);
            context.Database.EnsureCreated();
            context.Products.AddRange(GetProducts());
            context.SaveChanges();
            return context;
        }
        public static void Destroy(ApplicationDbContext dbContext)
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }
    }
}
