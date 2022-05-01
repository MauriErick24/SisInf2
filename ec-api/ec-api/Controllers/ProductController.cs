using core.Communication;
using interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using models;
using System.Threading.Tasks;

namespace ec_api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/product")]
    public class ProductController : ControllerBase
    {
        IProductService<AppResponse<Product>> _productService;

        public ProductController(IProductService<AppResponse<Product>> productService)
        {
            _productService = productService;
        }

        [HttpPost]
        [EnableCors("AppPolicy")]
        public async Task<IActionResult> AddProduct(Product product)
        {
            var token = HttpContext.Request.Headers["Authorization"];
            var result = await _productService.AddProduct(product, token);
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(new
            {
                Id = result.Entity.Id,
                SellerId = result.Entity.SellerId,
                Name = result.Entity.Name,
                Description = result.Entity.Description,
                Price = result.Entity.Price,
                CreatedAt = result.Entity.CreatedAt,
                UpdatedAt = result.Entity.UpdatedAt
            });
        }
    }
}
