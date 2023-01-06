using BlogApp_SemihKaraoglan.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp_SemihKaraoglan.Business.Abstract
{
    public interface ICommentReplyService
    {
        #region Generics
        Task<CommentReply> GetByIdAsync(int id);
        Task<List<CommentReply>> GetAllAsync(Expression<Func<CommentReply, bool>> expression);
        Task CreateAsync(CommentReply commentReply);
        void Update(CommentReply commentReply);
        void Delete(CommentReply commentReply);
        #endregion

        #region Comment Reply

        #endregion
    }
}
