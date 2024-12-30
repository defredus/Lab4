using Lab3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Lab3.Models;

namespace Lab3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // Конструктор с внедрением зависимости для логирования
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Действие для главной страницы
        public IActionResult Index()
        {
            return View();
        }

        // Действие для страницы "Privacy"
        public IActionResult Privacy()
        {
            return View();
        }

        // Действие для обработки ошибок
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
