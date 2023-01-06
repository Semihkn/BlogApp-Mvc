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
    public class CategoryManager : ICategoryService
    {
        private ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task CreateAsync(Category category)
        {
           await _categoryRepository.CreateAsync(category);
        }

        public void Delete(Category category)
        {
            _categoryRepository.Delete(category);
        }

        public async Task<List<Category>> GetAllAsync(Expression<Func<Category, bool>> expression)
        {
           return await _categoryRepository.GetAllAsync(expression);
        }

        public async Task<List<Category>> GetAllCategoriesAsync(bool isDeleted)
        {
            return await _categoryRepository.GetAllCategoriesAsync(isDeleted);
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }

        public async Task<Category> GetCategoryWithOneTagAsync(int id)
        {
            return await _categoryRepository.GetCategoryWithOneTagAsync(id);
        }

        public async Task<List<Category>> GetCategoryWithPostAsync(int id)
        {
            return await _categoryRepository.GetCategoryWithPostAsync(id);
        }

        public async Task<List<Category>> GetCategoryWithTagsAsync(int id)
        {
            return await _categoryRepository.GetCategoryWithTagsAsync(id);
        }

        public void IsDelete(Category category)
        {
            _categoryRepository.IsDelete(category);
        }

        public void Update(Category category)
        {
            _categoryRepository.Update(category);
        }
    }
}
