using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using example.Models;
using example.Repositories;
using System.Security.Claims;

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

        [HttpGet]
        public IActionResult CreateArticles()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateArticles(Articles articles)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            articles.AuthorIdId = userId;
            var result = await _articlesRepository.CreateArticlesAsync(articles);

            return View();
        }
    }
}
