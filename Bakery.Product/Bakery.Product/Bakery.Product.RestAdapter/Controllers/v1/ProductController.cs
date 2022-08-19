using Bakery.Product.DomainApi.Port;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bakery.Product.RestAdapter.Controllers.v1
{
    [Authorize]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IRequestProduct<Bakery.Product.DomainApi.Model.Product> _requestProduct;

        public ProductController(IRequestProduct<Bakery.Product.DomainApi.Model.Product> requestProduct)
        {
            _requestProduct = requestProduct;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var deals = _requestProduct.GetValues();
            return Ok(deals);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetProduct(int id)
        {
            var result = _requestProduct.GetValue(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddInventory([FromBody] Bakery.Product.DomainApi.Model.Product product)
        {
            if (User != null)
                product.User = User.Identity.Name;
            var result = _requestProduct.AddValue(product);
            if (result == null)
                return BadRequest("Product already exists");
            return Ok(result);
        }
    }
}
