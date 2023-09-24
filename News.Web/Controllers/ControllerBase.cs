using Microsoft.AspNetCore.Mvc;

namespace News.Web.Controllers
{

    public class ControllerBase : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
