using BlogApp_SemihKaraoglan.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp_SemihKaraoglan.Business.Abstract
{
    public interface IPostExtensionService
    {
        #region Generics
        Task<PostExtension> GetByIdAsync(int id);
        Task<List<PostExtension>> GetAllAsync(Expression<Func<PostExtension, bool>> expression);
        Task CreateAsync(PostExtension postExtension);
        void Update(PostExtension postExtension);
        void Delete(PostExtension postExtension);
        #endregion

        #region Post Extension

        #endregion
    }
}
