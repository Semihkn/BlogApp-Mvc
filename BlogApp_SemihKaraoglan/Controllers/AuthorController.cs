using BlogApp_SemihKaraoglan.Business.Abstract;
using BlogApp_SemihKaraoglan.Core;
using BlogApp_SemihKaraoglan.Entity;
using BlogApp_SemihKaraoglan.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Claims;

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

        #region Post
        [Route("/PostList")]
        [HttpGet]
        public async Task<IActionResult> PostList(bool isDeleted = false)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userId);

            var author = await _userManager.FindByIdAsync(user.Id);

            var posts = await _postService.GetAllAsync(p=>p.Id>0);
            ViewBag.IsDeleted = isDeleted;
            return View(posts);
        }

        [HttpGet]
        [Route("/PostCreate")]
        public async Task<IActionResult> PostCreate()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = _userManager.Users.FirstOrDefault(x => x.Id == userId);
            var author = await _userManager.FindByEmailAsync(user.Email);

            ViewBag.Author = author;
            ViewBag.Categories = await _categoryService.GetAllAsync(c => c.IsDeleted == false);
            return View();//viewModel - UIModel
        }

        [HttpPost]
        [Route("/PostCreate")]
        public async Task<IActionResult> PostCreate([FromBody] PostModel postModel)
        {

            if (ModelState.IsValid)
            {
                var url = Jobs.MakeUrl(postModel.Id + postModel.Title);
                Post post = new Post()
                {
                    Title = postModel.Title,
                    PostContent = postModel.PostContent,
                    Url = url,
                    IsDeleted = !postModel.IsDeleted,
                    Author = postModel.Author,
                    HeroImageUrl = postModel.HeroImageUrl,
                    CreateTimeUtc = postModel.CreateTimeUtc
                    
                };

                await _postService.CreateAsync(post, postModel.CategoryId);
                return RedirectToAction("Index");
            }

            if (postModel.CategoryId == 0)
            {
                ViewBag.CategoryErrorMessage = "Please choose a category!";
            }
            else
            {
                ViewData["SelectedCategory"] = postModel.CategoryId;
            }
            ViewBag.Categories = await _categoryService.GetAllAsync(c => c.IsDeleted == false);
           // ViewBag.Tags = await _tagService.GetAllAsync(c => c.IsDeleted == false);
            return View(postModel);
        }

        [HttpGet]
        public async Task<IActionResult> PostEdit(int id)
        {
            var post = await _postService.GetPostWithCategoriesAsync(id);
            PostModel postModel = new PostModel()
            {
                Id = post.Id,
                Title = post.Title,
                PostContent = post.PostContent,
                HeroImageUrl = post.HeroImageUrl,
                IsDeleted = post.IsDeleted,
                SelectedCategory = post
                    .PostCategory
                    .Select(pc => pc.Category)
                    .FirstOrDefault()
                
            };
            ViewBag.Categories = await _categoryService.GetAllAsync(c => c.IsDeleted == false);
           // ViewBag.Tags = await _tagService.GetAllAsync(c => c.IsDeleted == false);
            return View(postModel);
        }

        [HttpPost]
        public async Task<IActionResult> PostEdit(PostModel postModel, int categoryId)
        {

            string url = Jobs.MakeUrl(postModel.Title);
            if (ModelState.IsValid && categoryId > 0)
            {
                var post = await _postService.GetByIdAsync(postModel.Id);


                if (post == null)
                {
                    return NotFound();
                }

                post.Title = postModel.Title;
                post.Url = url;
                post.HeroImageUrl = postModel.HeroImageUrl;
                post.PostContent = postModel.PostContent;
                post.IsDeleted = !postModel.IsDeleted;
                post.CreateTimeUtc = postModel.CreateTimeUtc;              
               // post.Tags = postModel.SelectedTags;


                await _postService.UpdateAsync(post, categoryId);
                return RedirectToAction("PostList");
            }
            if (categoryId == null)
            {
                ViewBag.CategoryErrorMessage = "Choose a subject!";
            }
            else
            {
                postModel.SelectedCategory.Id = categoryId;
            }

            ViewBag.Categories = await _categoryService.GetAllAsync(c => c.IsDeleted == false);
          //ViewBag.Subjects = await _tagService.GetAllAsync(c => c.IsDeleted == false);
            return View(postModel);
        }

        [Route("/PostDelete")]
        [HttpGet]
        public async Task<IActionResult> PostDelete(int id)
        {
            Post post = await _postService.GetByIdAsync(id);
            if (post != null)
            {
                post.IsDeleted = post.IsDeleted ? false : true;
                _postService.IsDelete(post);
            }
            return RedirectToAction("PostList");
        }

        [Route("/PostDeletePermanently")]
        [HttpGet]
        public async Task<IActionResult> PostDeletePermanently(int id)
        {
            var post = await _postService.GetByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            _postService.Delete(post);
            return Redirect("/Author/PostList?isDeleted=true");
        }
        #endregion
    }
}
