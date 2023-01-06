using BlogApp_SemihKaraoglan.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp_SemihKaraoglan.Business.Abstract
{
    public interface ICommentService
    {
        #region Generics
        Task<Comment> GetByIdAsync(int id);
        Task<List<Comment>> GetAllAsync(Expression<Func<Comment, bool>> expression);
        Task CreateAsync(Comment comment);
        void Update(Comment comment);
        void Delete(Comment comment);
        #endregion

        #region Comment

        #endregion
    }
}
