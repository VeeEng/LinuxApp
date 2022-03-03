using Microsoft.AspNetCore.Mvc;

namespace LinuxApp.Api.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return new RedirectResult("~/swagger");
        }
    }
}
