using BlogApp_SemihKaraoglan.Data.Abstract;
using BlogApp_SemihKaraoglan.Data.Concrete.EFCore;
using BlogApp_SemihKaraoglan.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp_SemihKaraoglan.Data.Concrete
{
    public class EFCorePostRepository : EFCoreGenericRepository<Post>, IPostRepository
    {
        public EFCorePostRepository(BlogAppContext dbContext) : base(dbContext)
        {
        }

        public async Task CreateAsync(Post post, int categoryId) //
        {
            await context.Posts.AddAsync(post);
            await context.SaveChangesAsync();
        }

        public async Task<List<Post>> GetAllPostsAsync()
        {
            return await context
                .Posts
                .Include(p => p.Author)
                .Include(p => p.Tags)
                .Where(p => p.IsPublished == true)
                .ToListAsync();
        }

        public async Task<int> GetCountByCategoryAsync(string category)
        {
            var posts = context.Posts.AsQueryable();
            if (!string.IsNullOrEmpty(category))
            {
                posts = posts
                   .Include(p => p.Tags)
                   .Include(p => p.PostCategory)
                   .ThenInclude(pc => pc.Category)
                   .Where(p => p.PostCategory.Any(pc => pc.Category.Url == category));
            };

            return await posts.CountAsync();
        }

        public async Task<List<Post>> GetHomePostsAsync(string category)
        {
            var posts = context
                .Posts
                .Include(s => s.Author)
                .Include(s => s.Tags)
                .AsQueryable();


            if (!string.IsNullOrEmpty(category))
            {
                posts = posts
                    .Include(s => s.PostCategory)
                    .ThenInclude(sc => sc.Category)
                    .Where(s => s.PostCategory.Any(sc => sc.Category.Url == category));
            }
            var a = posts.ToList();

            return await posts.ToListAsync();
        }

        public async Task<List<Post>> GetInActivatedPostsAsync()
        {
            return await context
                 .Posts
                 .Include(p => p.Tags)
                 .Include(p => p.Author)
                 .Where(p => p.IsDeleted == true)
                 .ToListAsync();
        }

        public async Task<Post> GetPostDetailsAsync(string url)
        {
            return await context
               .Posts
               .Include(s => s.Author)
               .Include(s => s.Tags)
               .Where(s => s.Url == url)
               .Include(s => s.PostCategory)
               .ThenInclude(sc => sc.Category)
               .FirstOrDefaultAsync();
        }

        public async Task<List<Post>> GetPostsByAuthorAsync(int authorId)
        {
            var posts = context
                .Posts
                .Include(s => s.Author)
                //.Where(s => s.Author == authorId && s.IsDeleted == false)
                .ToListAsync();

            return await posts;
        }

        public async Task<List<Post>> GetPostsByCategoryAsync(string category, int page, int pageSize)
        {
            var posts = context.Posts
                .Include(s => s.Author)
                .Include(s => s.Tags)
                .AsQueryable();

            if (!string.IsNullOrEmpty(category))
            {
                posts = posts
                    .Include(s => s.PostCategory)
                    .ThenInclude(sc => sc.Category)
                    .Where(s => s.PostCategory.Any(sc => sc.Category.Url == category));
            };

            return await posts
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Post> GetPostWithCategoriesAsync(int id)
        {
            return await context
                .Posts
                .Include(s => s.Author)
                .Include(s => s.Tags)
                .Where(s => s.Id == id && s.IsDeleted == false)
                .Include(s => s.PostCategory)
                .ThenInclude(sc => sc.Category)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Post>> GetSearchResultAsync(string searchString)
        {
            return await context
               .Posts
               .Include(s => s.Tags)
               .Include(s => s.Author)
               .Where(s => s.Title.ToLower().Contains(searchString.ToLower()) || s.PostContent.ToLower().Contains(searchString.ToLower()))
               .ToListAsync();
        }

        public async Task<List<Post>> GetSearchResultAsync(Tag tag, Category category, string searchString)
        {
            return await context
               .Posts
               .Include(s => s.Tags)
               .Include(s => s.PostCategory)
               .ThenInclude(sc => sc.Category)
               .Where(s => s.PostCategory.Any(sc => sc.Category.Name == category.Name))
               .ToListAsync();

        }

        public void IsDelete(Post post)
        {
            if (post.IsDeleted == false)
            {
                post.IsDeleted = true;
            }
            else
            {
                post.IsDeleted = false;
            }
            context.Update(post);
            context.SaveChanges();
        }

        public async Task UpdateAsync(Post post, int categoryId)
        {
            var newPost = await context
               .Posts
              .Include(s => s.Tags)
              .Include(s => s.PostCategory)
              .FirstOrDefaultAsync(s => s.Id == post.Id);

            newPost.Title = post.Title;
            newPost.Author = post.Author;
            newPost.IsDeleted = post.IsDeleted;
            newPost.HeroImageUrl = post.HeroImageUrl;
            newPost.Url = post.Url;
            newPost.PostCategory = post.PostCategory;
            newPost.Tags = post.Tags;
            newPost.CommentEnabled = post.CommentEnabled;
            newPost.IsFeedIncluded = post.IsFeedIncluded;
            newPost.IsFeatured = post.IsFeatured;
            newPost.IsOriginal = post.IsOriginal;
            newPost.IsPublished = post.IsPublished;
            newPost.PostContent = post.PostContent;
            newPost.UserId = post.UserId;

            context.Update(newPost);
            context.SaveChanges();
        }
    }
}
