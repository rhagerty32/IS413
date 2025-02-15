using Microsoft.AspNetCore.Mvc;

namespace mission06_Hagerty.Controllers
{
    public class JoelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}