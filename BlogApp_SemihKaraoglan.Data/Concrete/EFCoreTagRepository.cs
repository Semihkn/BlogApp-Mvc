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
    public class EFCoreTagRepository : EFCoreGenericRepository<Tag>, ITagRepository
    {
        public EFCoreTagRepository(BlogAppContext dbContext) : base(dbContext)
        {
        }
    }
}
