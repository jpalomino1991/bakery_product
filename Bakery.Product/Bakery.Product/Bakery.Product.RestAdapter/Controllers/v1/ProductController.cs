using Bakery.Commons.Bakery.Commons.Domain.Port;
using Bakery.Product.DomainApi.Port;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bakery.Product.RestAdapter.Controllers.v1
{
    [Authorize]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IRequestProduct<Bakery.Product.DomainApi.Model.Product> _requestProduct;
        private readonly IStorageAccountHelper _storageAccountHelper;

        public ProductController(IRequestProduct<Bakery.Product.DomainApi.Model.Product> requestProduct, IStorageAccountHelper storageAccountHelper)
        {
            _requestProduct = requestProduct;
            _storageAccountHelper = storageAccountHelper;
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

        [HttpPost(nameof(Upload))]
        public async Task<IActionResult> Upload(IFormFile file, int productId)
        {
            string blobPath = await _storageAccountHelper.UploadFileAsync(file);
            var product = _requestProduct.GetValue(productId);
            product.ImageUrl = blobPath;
            _requestProduct.UpdateValue(product);
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
