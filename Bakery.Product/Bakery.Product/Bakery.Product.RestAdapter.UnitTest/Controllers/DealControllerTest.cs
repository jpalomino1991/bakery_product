using Bakery.Product.DomainApi.Model;
using Bakery.Product.DomainApi.Port;
using Bakery.Product.RestAdapter.Controllers.v1;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace Bakery.Product.RestAdapter.UnitTest.Controllers
{
    public class DealControllerTest
    {
        private ProductController _controller;
        private Mock<IRequestProduct<Deal>> _requestDealMock;

        [SetUp]
        public void Setup()
        {
            _requestDealMock = new Mock<IRequestProduct<Deal>>();
            _controller = new DealController(_requestDealMock.Object);
        }

        [Test]
        public void GetAllDealTestOkResult()
        {
            var response = _controller.Get();
            Assert.IsInstanceOf<OkObjectResult>(response);
        }

        [Test]
        public void GetAllDealByIdTestOkResult()
        {
            var response = _controller.Get(1);
            Assert.IsInstanceOf<OkObjectResult>(response);
        }
    }
}
