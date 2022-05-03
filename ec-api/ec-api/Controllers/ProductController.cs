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
        IProductService<AppResponse<Product>, PagedList<Product>> _productService;

        public ProductController(IProductService<AppResponse<Product>, PagedList<Product>> productService)
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

        [AllowAnonymous]
        [HttpGet]
        [EnableCors("AppPolicy")]
        public async Task<IActionResult> ListProducts([FromQuery(Name = "pageNumber")] int? pageNumber, [FromQuery(Name = "pageSize")] int? pageSize)
        {
            PagedList<Product> result;
            if (pageNumber is null && pageSize is null)
            {
                result = await _productService.ListProducts();

                return Ok(new {
                    Data = result,
                    CurrentPage = result.CurrentPage,
                    PageSize = result.PageSize,
                    NextPageNumber = result.NextPageNumber,
                    PreviousPageNumber = result.PreviousPageNumber,
                    TotalCount = result.TotalCount,
                    TotalPages = result.TotalPages
                });
            }

            if (pageNumber is null)
            {
                pageNumber = 1;
            }
            
            if (pageSize is null)
            {
                pageSize = 20;
            }
            
            result = await _productService.ListProducts((int) pageNumber, (int) pageSize);

            return Ok(new {
                Data = result,
                CurrentPage = result.CurrentPage,
                PageSize = result.PageSize,
                NextPageNumber = result.NextPageNumber,
                PreviousPageNumber = result.PreviousPageNumber,
                TotalCount = result.TotalCount,
                TotalPages = result.TotalPages
            });
        }
    }
}
