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
    public class CommentReplyManager : ICommentReplyService
    {
        private ICommentReplyRepository _commentReplyRepository;

        public CommentReplyManager(ICommentReplyRepository commentReplyRepository)
        {
            _commentReplyRepository = commentReplyRepository;
        }

        public async Task CreateAsync(CommentReply commentReply)
        {
            await _commentReplyRepository.CreateAsync(commentReply);
        }

        public void Delete(CommentReply commentReply)
        {
            _commentReplyRepository.Delete(commentReply);
        }

        public async Task<List<CommentReply>> GetAllAsync(Expression<Func<CommentReply, bool>> expression)
        {
            return await _commentReplyRepository.GetAllAsync(expression);
        }

        public async Task<CommentReply> GetByIdAsync(int id)
        {
            return await _commentReplyRepository.GetByIdAsync(id);
        }

        public void Update(CommentReply commentReply)
        {
            _commentReplyRepository.Update(commentReply);
        }
    }
}


