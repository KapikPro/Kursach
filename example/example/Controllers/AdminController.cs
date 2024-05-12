using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using example.Models;
using example.Repositories;

namespace example.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {

        private ArticlesRepository _articlesRepository;

        public AdminController(ArticlesRepository articlesRepository)
        {
            _articlesRepository = articlesRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Users()
        {
            var ListUsers = new List<string>();

            return View(ListUsers);
        }

        public async Task<ActionResult> Articles()
        {
            var ListArticles =await _articlesRepository.GetArticlesAsync();

            return View(ListArticles);
        }

        public IActionResult CreateArticles()
        {
            return View();
        }
    }
}
