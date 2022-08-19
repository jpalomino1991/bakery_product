using Bakery.Product.DomainApi.Model;
using Bakery.Product.Persistence.Adapter.UnitTest.Common;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Threading.Tasks;
using ProductModel = Bakery.Product.DomainApi.Model.Product;

namespace Bakery.Product.Persistence.Adapter.UnitTest.Context
{
    public class ApplicationDbContextTest
    {
        [Test]
        public void CanInsertDealIntoDatabase()
        {
            using var context = ApplicationDbContextFactory.Create();
            var product = new ProductModel();
            context.Products.Add(product);
            Assert.AreEqual(EntityState.Added, context.Entry(product).State);

            var result = context.SaveChangesAsync();
            Assert.AreEqual(1, result.Result);
            Assert.AreEqual(Task.CompletedTask.Status, result.Status);
            Assert.AreEqual(EntityState.Unchanged, context.Entry(product).State);

        }

        [Test]
        public void CanDeleteDealIntoDatabase()
        {
            using var context = ApplicationDbContextFactory.Create();
            var product = new ProductModel();
            context.Products.Remove(product);
            Assert.AreEqual(EntityState.Deleted, context.Entry(product).State);
        }
    }
}
