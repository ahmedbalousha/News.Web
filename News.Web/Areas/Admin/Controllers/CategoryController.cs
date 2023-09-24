using Microsoft.AspNetCore.Mvc;
using News.Dtos.Helpers;
using News.Web.Dtos;
using News.Web.Service.Categories;
using News.Constants;
using Results = News.Constants.Results;

namespace News.Web.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService) 
        {
            _categoryService = categoryService;

        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        public async Task<JsonResult> GetCategoryData(Pagination pagination, string query)
        {
            var result = await _categoryService.GetAll(pagination, query);
            return Json(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto dto)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.Create(dto);
                return Ok(Results.AddSuccessResult());

            }
            return View(dto);
        }
        [HttpGet]

        public async Task<IActionResult> Update(int id)
        {
            var user = await _categoryService.Get(id);
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryDto dto)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.Update(dto);
                return Ok(Results.EditSuccessResult());
            }
            return View(dto);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.Delete(id);
            return Ok(Results.DeleteSuccessResult());
        }
    }
}
