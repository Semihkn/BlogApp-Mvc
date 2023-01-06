using BlogApp_SemihKaraoglan.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp_SemihKaraoglan.Data.Abstract
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void IsDelete(Category category);
        Task<List<Category>> GetAllCategoriesAsync(bool isDeleted);
        Task<List<Category>> GetCategoryWithPostAsync(int id);
        Task<List<Category>> GetCategoryWithTagsAsync(int id);
        Task<Category> GetCategoryWithOneTagAsync(int id);
    }
}
