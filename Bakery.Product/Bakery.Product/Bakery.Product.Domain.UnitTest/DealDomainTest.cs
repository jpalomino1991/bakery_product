using Bakery.Product.DomainApi.Model;
using Bakery.Product.Persistence.Adapter.UnitTest.Common;
using NUnit.Framework;

namespace Bakery.Product.Domain.UnitTest
{
    public class DealDomainTest
    {
        private ProductDomain<Deal> _dealDomain;

        [Test]
        public void GetDealsTest()
        {
            using var context = ApplicationDbContextFactory.Create();
            _dealDomain = new ProductDomain<Deal>(context);
            var deals = _dealDomain.GetValues();
            Assert.AreEqual(3, deals.Count);
            Assert.AreEqual(1, deals[0].Id);
            Assert.AreEqual("ABC", deals[0].Name);
            Assert.AreEqual("ABC deal 123", deals[0].Description);

        }

        [Test]
        public void GetDealByIdTest()
        {
            using var context = ApplicationDbContextFactory.Create();
            _dealDomain = new ProductDomain<Deal>(context);
            var deals = _dealDomain.GetValue(1);
            Assert.AreEqual(1, deals.Id);
            Assert.AreEqual("ABC", deals.Name);
            Assert.AreEqual("ABC deal 123", deals.Description);

        }
    }
}