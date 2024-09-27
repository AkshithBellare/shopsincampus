using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shopsincampus.business.Interfaces;
using shopsincampus.data.Models;

namespace shopsincampus.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthManager _authManager;
        public AuthController(IAuthManager authManager)
        {
            _authManager = authManager;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] Login model)
        {
            if (model.UserName == "test" && model.Password == "password") 
            {
                var token = _authManager.GenerateJwtToken("userId"); 
                return Ok(new { Token = token });
            }
            return Unauthorized();
        }
    }
}
