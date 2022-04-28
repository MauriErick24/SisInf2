using core.Communication;
using interfaces.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using models;
using System.Threading.Tasks;

namespace ec_api.Controllers
{
    [ApiController]
    [Route("/api/dessert")]
    public class DessertController : ControllerBase
    {
        IDessertService<AppResponse<Dessert>> _dessertService;

        public DessertController(IDessertService<AppResponse<Dessert>> dessertService)
        {
            _dessertService = dessertService;
        }
        
        [HttpGet]
        [EnableCors("AppPolicy")]
        public async Task<IActionResult> GetAllAsync()
        {
            var desserts = await _dessertService.ListAsync();

            return Ok(new { data = desserts });
        }

        [HttpPost]
        [EnableCors("AppPolicy")]
        public async Task<IActionResult> AddAsync([FromBody] Dessert dessert)
        {
            var result = await _dessertService.SaveAsync(dessert);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Entity);
        }
    }
}
