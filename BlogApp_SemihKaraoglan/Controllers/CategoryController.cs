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
        private IPostService _showCardService;
        private ITagService _tagService;


        public CategoryController(ICategoryService categoryService, IPostService showCardService, ITagService tagService)
        {
            _categoryService = categoryService;
            _showCardService = showCardService;
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
            List<Post> posts = await _showCardService.GetPostsByCategoryAsync(category, page, pageSize);

            PageInfo pageInfo = new PageInfo()
            {
                TotalItems = await _showCardService.GetCountByCategoryAsync(category),
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
