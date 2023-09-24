﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using News.Dtos.Helpers;
using News.Web.Dtos;
using News.Web.Service.Categories;
using News.Web.Service.Posts;
using Results = News.Constants.Results;


namespace News.Web.Areas.Admin.Controllers
{
    public class PostController : BaseController
    {
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;

        public PostController(IPostService postService, ICategoryService categoryService)
        {
           _categoryService = categoryService;
           _postService = postService;

        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

      
        public async Task<JsonResult> GetPostsData(Pagination pagination, Query query)
        {
            var result = await _postService.GetAll(pagination, query);
            return Json(result);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["categories"] = new SelectList(await _categoryService.GetCategoryList(), "Id", "Name");
            

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreatePostDto dto)
        {
            if (ModelState.IsValid)
            {
                await _postService.Create(dto);
                return Ok(Results.AddSuccessResult());

            }
            ViewData["categories"] = new SelectList(await _categoryService.GetCategoryList(), "Id", "Name");

            return View(dto);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            ViewData["categories"] = new SelectList(await _categoryService.GetCategoryList(), "Id", "Name");

            var post = await _postService.Get(id);
            return View(post);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdatePostDto dto)
        {
            if (ModelState.IsValid)
            {
                await _postService.Update(dto);
                return Ok(Results.EditSuccessResult());
            }
            ViewData["categories"] = new SelectList(await _categoryService.GetCategoryList(), "Id", "Name");


            return View(dto);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _postService.Delete(id);
            return Ok(Results.DeleteSuccessResult());
        }
       
    }

}

