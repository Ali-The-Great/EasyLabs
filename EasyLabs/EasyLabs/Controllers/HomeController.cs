using EasyLabs.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EasyLabs.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult SignUp()
        {
            ViewBag.Message = "User Sign Up";
            return View();
        }
    }
}