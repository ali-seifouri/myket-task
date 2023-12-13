using Microsoft.AspNetCore.Mvc;

namespace Myket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;


        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }


        [HttpGet]
        public async Task<ActionResult> GetProduct(string productName)
        {
            var result = await _productsService.GetProductAsync(productName);
            return Ok(result);
        }
    }
}
