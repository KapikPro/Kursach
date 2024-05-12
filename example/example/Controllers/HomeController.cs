using example.Models;
using example.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
