using Microsoft.AspNetCore.Mvc;
using News.Web.Service.Posts;

namespace News.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetAll()
        {
            var posts = await _postService.GetAll();
            return View(posts);
        }
        public async Task<IActionResult> Get(int id)
        {
            var post = await _postService.GetById(id);
            return View(post);
        }
    }
}
