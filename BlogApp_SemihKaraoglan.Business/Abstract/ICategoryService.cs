using BlogApp_SemihKaraoglan.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp_SemihKaraoglan.Business.Abstract
{
    public interface ICategoryService
    {
        #region Generics
        Task<Category> GetByIdAsync(int id);
        Task<List<Category>> GetAllAsync(Expression<Func<Category, bool>> expression);
        Task CreateAsync(Category category);
        void Update(Category category);
        void Delete(Category category);
        #endregion

        #region Category
        void IsDelete(Category category);
        Task<List<Category>> GetAllCategoriesAsync(bool isDeleted);
        Task<List<Category>> GetCategoryWithPostAsync(int id);
        Task<List<Category>> GetCategoryWithTagsAsync(int id);
        Task<Category> GetCategoryWithOneTagAsync(int id);

        #endregion
    }
}
