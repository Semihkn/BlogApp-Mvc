using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp_SemihKaraoglan.Entity
{
    public class PostCategory
    {
        public int PostId { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }
        public Post Post { get; set; }
    }
}

