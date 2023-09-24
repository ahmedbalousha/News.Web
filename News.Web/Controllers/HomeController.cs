using Microsoft.AspNetCore.Mvc;
using News.Web.Models;
using System.Diagnostics;

namespace News.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
    }
}