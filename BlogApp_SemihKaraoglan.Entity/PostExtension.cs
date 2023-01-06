using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp_SemihKaraoglan.Entity
{
    public class PostExtension: BaseEntity
    {
        public int PostId { get; set; }
        public int Hits { get; set; }
        public int Likes { get; set; }
        public Post Post { get; set; }
    }
}
