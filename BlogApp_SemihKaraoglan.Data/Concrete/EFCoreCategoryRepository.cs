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
    public class EFCoreCategoryRepository : EFCoreGenericRepository<Category>, ICategoryRepository
    {
        public EFCoreCategoryRepository(BlogAppContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Category>> GetAllCategoriesAsync(bool isDeleted)
        {
            return await context
             .Categories
             .Where(c => c.IsDeleted == isDeleted)
             .ToListAsync();
        }

        public async Task<Category> GetCategoryWithOneTagAsync(int id) //fix
        {
            return await context
               .Categories
               .Where(c => c.Id == id)
               .Include(c => c.PostCategory)
               .ThenInclude(pc => pc.Post.Tags)
               .FirstOrDefaultAsync();
        }

        public async Task<List<Category>> GetCategoryWithPostAsync(int id)
        {
            return await context
              .Categories
              .Where(c => c.Id == id)
              .Include(c => c.PostCategory)
              .ThenInclude(pc => pc.Post)
              .ToListAsync();
        }

        public async Task<List<Category>> GetCategoryWithTagsAsync(int id)
        {
           return await context
                .Categories
                .Where(c => c.Id == id)
                .Include(c => c.PostCategory)
                .ThenInclude(pc => pc.Post.Tags)
                .ToListAsync();
        }

        public void IsDelete(Category category)
        {
            context.Update(category);
            context.SaveChanges();
        }
    }
}
