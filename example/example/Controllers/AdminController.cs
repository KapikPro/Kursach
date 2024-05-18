using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using example.Models;
using example.Repositories;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace example.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {

        private ArticlesRepository _articlesRepository;
        private UserManager<User> _userManager;

        public AdminController(ArticlesRepository articlesRepository, UserManager<User> userManager)
        {
            _articlesRepository = articlesRepository;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Users()
        {
            var list = await _userManager.Users.ToListAsync();

            return View(list);
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
            articles.IsActive = true;
            articles.Date = DateTime.UtcNow;
            var result = await _articlesRepository.CreateArticlesAsync(articles);

            return View();
        }
    }
}
