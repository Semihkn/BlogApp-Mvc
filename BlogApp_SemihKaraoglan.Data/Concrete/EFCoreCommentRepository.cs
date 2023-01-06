using BlogApp_SemihKaraoglan.Data.Abstract;
using BlogApp_SemihKaraoglan.Data.Concrete.EFCore;
using BlogApp_SemihKaraoglan.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp_SemihKaraoglan.Data.Concrete
{
    public class EFCoreCommentRepository : EFCoreGenericRepository<Comment>, ICommentRepository
    {
        public EFCoreCommentRepository(BlogAppContext dbContext) : base(dbContext)
        {
        }
    }
}
