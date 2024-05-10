using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace example.Controllers
{
    [Authorize(Roles = "Admin")]
    public class Admin : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Users()
        {
            var ListUsers = new List<string>();

            return View();
        }
    }
}
