using BlogApp_SemihKaraoglan.Business.Abstract;
using BlogApp_SemihKaraoglan.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BlogApp_SemihKaraoglan.Controllers
{
    //[Authorize(Roles = "Author")]
    public class AuthorController : Controller
    {
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;
        private readonly ITagService _tagService;
        private readonly UserManager<CustomUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthorController(IPostService postService, ICategoryService categoryService, ITagService tagService, UserManager<CustomUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _postService = postService;
            _categoryService = categoryService;
            _tagService = tagService;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
