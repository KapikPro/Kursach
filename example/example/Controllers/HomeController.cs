using example.Models;
using example.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore;
using System.Diagnostics;
using System.Web;

namespace example.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private ArticlesRepository _articlesRepository;

        public HomeController(ILogger<HomeController> logger, ArticlesRepository articlesRepository)
        {
            _logger = logger;
            _articlesRepository = articlesRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<ActionResult> Articles()
        {
            var ListArticles = await _articlesRepository.GetArticlesAsync();

            return View(ListArticles);
        }

        [Route("Home/Article/{id?}")]
        public async Task<ActionResult> Article(int? id)
        {
            var article = await _articlesRepository.GetArticleAsync(id);

                return View(article);
        }
    }
}

