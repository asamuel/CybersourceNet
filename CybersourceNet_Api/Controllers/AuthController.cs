using CybersourceNet_App.Contracts;
using CybersourceNet_App.ViewModels.Auth;
using Microsoft.AspNetCore.Mvc;

namespace CybersourceNet_Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuth _auth;
        public AuthController(IAuth auth)
        {
            _auth = auth;
        }

        [HttpPost("login")]
        public IActionResult Login(UserLoginRequestViewModel userLoginViewModel)
        {
            var user = _auth.Authenticate(userLoginViewModel);

            if (user == null)
                return NotFound("User Not found");

            var token = _auth.GenerateToken(user);
            return Ok(token);
        }
    }
}
