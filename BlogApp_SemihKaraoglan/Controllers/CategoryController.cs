using BlogApp_SemihKaraoglan.Business.Abstract;
using BlogApp_SemihKaraoglan.Entity;
using BlogApp_SemihKaraoglan.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BlogApp_SemihKaraoglan.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;
        private IPostService _postService;
        private ITagService _tagService;


        public CategoryController(ICategoryService categoryService, IPostService postService, ITagService tagService)
        {
            _categoryService = categoryService;
            _postService = postService;
            _tagService = tagService;
        }

        public async Task<IActionResult> Index(bool isDeleted)
        {

            var categories = await _categoryService.GetAllCategoriesAsync(isDeleted);
            return View(categories);
        }

        public async Task<IActionResult> List(string category, int page = 1)  //List by category
        {
            const int pageSize = 9;
            List<Post> posts = await _postService.GetPostsByCategoryAsync(category, page, pageSize);

            PageInfo pageInfo = new PageInfo()
            {
                TotalItems = await _postService.GetCountByCategoryAsync(category),
                CurrentPage = page,
                ItemsPerPage = pageSize,
                CurrentCategory = category
            };

            PostViewModel postViewModel = new PostViewModel()
            {
                Posts = posts,
                PageInfo = pageInfo
            };
            return View(postViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _categoryService.GetAllCategoriesAsync(false);
            return Ok(categories);
        }

       
    }
}
