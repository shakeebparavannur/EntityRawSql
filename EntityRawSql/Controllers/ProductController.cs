using EntityRawSql.Models;
using EntityRawSql.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityRawSql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("getproductlist")]
        public async Task<List<Product>> GetProductsListAsync()
        {
            try
            {
                return await _productService.GetProductListAsync();
            }
            catch
            {
                throw;
            }
        }
        [HttpPost("addproduct")]
        public async Task<IActionResult> AddProductAsync(Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            try
            {
                var response = await _productService.AddProductAsync(product);
                return Ok(response);
            }
            catch
            {
                throw;
            }
        }
    }
}
