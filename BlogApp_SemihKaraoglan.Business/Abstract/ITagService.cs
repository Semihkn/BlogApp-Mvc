using BlogApp_SemihKaraoglan.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp_SemihKaraoglan.Business.Abstract
{
    public interface ITagService
    {
        #region Generics
        Task<Tag> GetByIdAsync(int id);
        Task<List<Tag>> GetAllAsync(Expression<Func<Tag, bool>> expression);
        Task CreateAsync(Tag tag);
        void Update(Tag tag);
        void Delete(Tag tag);
        #endregion

        #region Tag

        #endregion

    }
}
