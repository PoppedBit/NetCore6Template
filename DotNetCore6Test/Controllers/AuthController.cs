
using DotNetCore6Test.Entities.Auth;
using DotNetCore6Test.Models.Auth;
using DotNetCore6Test.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

            // Claims
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Id.ToString())
            };

            ClaimsIdentity identity = new ClaimsIdentity(claims, "MyClaims");

            ClaimsPrincipal principal = new ClaimsPrincipal(new[] {identity});

            HttpContext.SignInAsync(principal);

            return Ok(new { userId = user.Id});
        }

        [HttpPost("Logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return Ok();
        }
    }
}
