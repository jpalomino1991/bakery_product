using Bakery.Product.DomainApi.Port;
using Bakery.Product.RestAdapter.Controllers.v1;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ProductModel = Bakery.Product.DomainApi.Model.Product;

namespace Bakery.Product.RestAdapter.UnitTest.Controllers
{
    public class ProductControllerTest
    {
        private ProductController _controller;
        private Mock<IRequestProduct<ProductModel>> _requestProductMock;

        [SetUp]
        public void Setup()
        {
            _requestProductMock = new Mock<IRequestProduct<ProductModel>>();
            _controller = new ProductController(_requestProductMock.Object);
        }

        [Test]
        public void GetAllDealTestOkResult()
        {
            var response = _controller.GetProducts();
            Assert.IsInstanceOf<OkObjectResult>(response);
        }

        [Test]
        public void GetAllDealByIdTestOkResult()
        {
            var response = _controller.GetProduct(1);
            Assert.IsInstanceOf<OkObjectResult>(response);
        }
    }
}
