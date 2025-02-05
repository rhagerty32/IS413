using Microsoft.AspNetCore.Mvc;

namespace SpikeballMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Calculator()
        {
            return View();
        }
    }
}