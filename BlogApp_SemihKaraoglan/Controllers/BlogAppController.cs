using BlogApp_SemihKaraoglan.Business.Abstract;
using BlogApp_SemihKaraoglan.Entity;
using BlogApp_SemihKaraoglan.Models;
using BlogApp_SemihKaraoglan.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp_SemihKaraoglan.Controllers
{
    public class BlogAppController : Controller
    {
        private readonly IPostService _postService;
        private readonly UserManager<CustomUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BlogAppController(IPostService postService, UserManager<CustomUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _postService = postService;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> PostList(string category, int page = 1) 
        {
            const int pageSize = 9;
            List<Post> posts = await _postService.GetAllPostsAsync();

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

        public async Task<IActionResult> ListByCategory(string category, int page = 1)
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

        public async Task<IActionResult> PostDetail(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return NotFound();
            }
            Post post = await _postService.GetPostDetailsAsync(url);

            PostDetailModel postDetailModel = new PostDetailModel()
            {
                Post = post,
                Category = post
                    .PostCategory
                    .Select(sc => sc.Category)
                    .FirstOrDefault()

            };
            return View(postDetailModel);
        }
        public async Task<IActionResult> Search(string q)
        {
            List<Post> searchResult = await _postService.GetSearchResultAsync(q);
            return View(searchResult);
        }
        //public async Task<IActionResult> AdvanceSearch(Tag tag, Category category, string searchString))
        //{
        //    List<Post> searchResult = await _postService.GetSearchResultAsync(tag,category,searchString);
        //    return View(searchResult);
        //}
    }
}
