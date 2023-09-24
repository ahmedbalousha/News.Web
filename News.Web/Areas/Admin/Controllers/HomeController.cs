using Microsoft.AspNetCore.Mvc;
using News.Web.Areas.Admin.Controllers;
using News.Web.Models;
using System.Diagnostics;

namespace News.Web.Controllers
{
    public class HomeAdminController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeAdminController()
        {
            
        }

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