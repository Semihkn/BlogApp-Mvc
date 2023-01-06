using BlogApp_SemihKaraoglan.Business.Abstract;
using BlogApp_SemihKaraoglan.Data.Abstract;
using BlogApp_SemihKaraoglan.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp_SemihKaraoglan.Business.Concrete
{
    public class PostManager : IPostService
    {
        private IPostRepository _postRepository;

        public PostManager(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task CreateAsync(Post post)
        {
            await _postRepository.CreateAsync(post);
        }

        public async Task CreateAsync(Post post, int categoryId)
        {
            await _postRepository.CreateAsync(post, categoryId);
        }

        public void Delete(Post post)
        {
            _postRepository.Delete(post);
        }

        public async Task<List<Post>> GetAllAsync(Expression<Func<Post, bool>> expression)
        {
            return await _postRepository.GetAllAsync(expression);
        }

        public async Task<List<Post>> GetAllPostsAsync()
        {
            return await _postRepository.GetAllPostsAsync();
        }

        public async Task<Post> GetByIdAsync(int id)
        {
            return await _postRepository.GetByIdAsync(id);
        }

        public async Task<int> GetCountByCategoryAsync(string category)
        {
            return await _postRepository.GetCountByCategoryAsync(category);
        }

        public async Task<List<Post>> GetHomePostsAsync(string category)
        {
            return await _postRepository.GetHomePostsAsync(category);
        }

        public async Task<List<Post>> GetInActivatedPostsAsync()
        {
            return await _postRepository.GetInActivatedPostsAsync();
        }

        public async Task<Post> GetPostDetailsAsync(string url)
        {
           return await _postRepository.GetPostDetailsAsync(url);
        }

        public async Task<List<Post>> GetPostsByAuthorAsync(int authorId)
        {
            return await _postRepository.GetPostsByAuthorAsync(authorId);
        }

        public async Task<List<Post>> GetPostsByCategoryAsync(string category, int page, int pageSize)
        {
            return await _postRepository.GetPostsByCategoryAsync(category, page, pageSize);
        }

        public async Task<Post> GetPostWithCategoriesAsync(int id)
        {
            return await _postRepository.GetPostWithCategoriesAsync(id);
        }

        public async Task<List<Post>> GetSearchResultAsync(string searchString)
        {
            return await _postRepository.GetSearchResultAsync(searchString);
        }

        public async Task<List<Post>> GetSearchResultAsync(Tag tag, Category category, string searchString)
        {
            return await _postRepository.GetSearchResultAsync(tag, category, searchString);
        }

        public void IsDelete(Post post)
        {
           _postRepository.IsDelete(post);
        }

        public void Update(Post post)
        {
            _postRepository.Update(post);
        }

        public async Task UpdateAsync(Post post, int categoryId)
        {
            await _postRepository.UpdateAsync(post, categoryId);
        }
    }
}
