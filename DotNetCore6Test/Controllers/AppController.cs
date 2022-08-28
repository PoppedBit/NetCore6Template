using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore6Test.Controllers
{
    [Route("[controller]")]
    public class AppController : ControllerBase
    {
        private IWebHostEnvironment _env;

        public AppController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [AllowAnonymous]
        [Produces("text/html")]
        public ContentResult Index()
        {
            string appRoot = _env.ContentRootPath;
            bool isAuthenticated = HttpContext.User.Identity.IsAuthenticated;

            string appIndex = appRoot + "/UI/"+(isAuthenticated ? "client" : "login")+"/build/index.html";

            string content = System.IO.File.ReadAllText(appIndex);

            return new ContentResult
            {
                ContentType = "text/html",
                Content = content
            };
        }
    }
}
