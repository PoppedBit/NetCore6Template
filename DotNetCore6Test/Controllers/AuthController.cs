
using DotNetCore6Test.Entities.Auth;
using DotNetCore6Test.Models.Auth;
using DotNetCore6Test.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore6Test.Controllers
{
    [Route("Auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login([FromBody] AuthenticateModel authModel)
        {
            string email = authModel.Email;
            string password = authModel.Password;

            User? user = _userService.Authenticate(email, password);

            if(user == null)
            {
                return Ok(new { message = "Email or Password is incorrect." });
            }

            return Ok();
        }

        public IActionResult Logout()
        {
            return Ok();
        }
    }
}
