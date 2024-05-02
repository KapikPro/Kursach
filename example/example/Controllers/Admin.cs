using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace example.Controllers
{
    public class Admin : Controller
    {
        [Authorize(Roles ="Admin")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Users()
        {
            return View();
        }
    }
}
