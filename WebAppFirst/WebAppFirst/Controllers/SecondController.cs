using Microsoft.AspNetCore.Mvc;

namespace WebAppFirst.Controllers
{
    public class SecondController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cart()
        {
            return View();
        }
    }
}
