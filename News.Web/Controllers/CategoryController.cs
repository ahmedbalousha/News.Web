using Microsoft.AspNetCore.Mvc;
using News.Web.Models;
using News.Web.Service.Categories;
using News.Web.ViewModels;

namespace News.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;

        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAll();
            return View(categories);
        }
    }
}
