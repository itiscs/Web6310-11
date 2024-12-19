using IdenApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace IdenApp.Controllers
{

    public class AdminController : Controller
    {
        ApplicationDbContext _context;
        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var users = _context.Users.ToList();

            return View(users);
        }
    }
}
