using BlogApp_SemihKaraoglan.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp_SemihKaraoglan.Data.Abstract
{
    public interface IPostRepository : IRepository<Post>
    {
        Task CreateAsync(Post post, int categoryId);
        Task<List<Post>> GetHomePostsAsync(string category);
        Task<Post> GetPostDetailsAsync(string url);
        Task<List<Post>> GetPostsByCategoryAsync(string category, int page, int pageSize);
        Task<int> GetCountByCategoryAsync(string category);
        Task<List<Post>> GetSearchResultAsync(string searchString);
        Task<Post> GetPostWithCategoriesAsync(int id);
        Task<List<Post>> GetAllPostsAsync();
        Task<List<Post>> GetInActivatedPostsAsync();
        void IsDelete(Post post);
        Task UpdateAsync(Post post, int categoryId);
        Task<List<Post>> GetSearchResultAsync(Tag tag, Category category, string searchString);
        Task<List<Post>> GetPostsByAuthorAsync(int authorId);
    }
}
