using Bakery.Product.DomainApi.Model;
using NUnit.Framework;
using ProductModel = Bakery.Product.DomainApi.Model.Product;

namespace Bakery.Product.DomainApi.UnitTest.Model
{
    public class ProductTest
    {
        private readonly ProductModel _product;
        private const string Name = "Test Deal name";
        private const string Description = "Test Deal description";

        public ProductTest()
        {
            _product = new ProductModel();
        }

        [Test]
        public void TestSetAndGetName()
        {
            _product.Name = Name;
            Assert.AreEqual(Name, _product.Name);
        }

        [Test]
        public void TestSetAndGetDescription()
        {
            _product.Description = Description;
            Assert.AreEqual(Description, _product.Description);
        }
    }
}
