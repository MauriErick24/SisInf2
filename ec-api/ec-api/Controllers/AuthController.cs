using core.Communication;
using interfaces.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using models;
using System.Threading.Tasks;

namespace ec_api.Controllers
{
    [ApiController]
    [Route("/api/auth")]
    public class AuthController : ControllerBase
    {
        private IUserService<AppResponse<UserAuthenticated>> _userService;
        public AuthController(IUserService<AppResponse<UserAuthenticated>> userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        [EnableCors("AppPolicy")]
        public async Task<IActionResult> LoginAsync([FromBody] UserPassword user)
        {
            var result = await _userService.Login(user);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Entity);
        }
    }
}
