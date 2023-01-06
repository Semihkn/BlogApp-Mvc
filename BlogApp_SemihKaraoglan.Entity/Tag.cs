using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp_SemihKaraoglan.Entity
{
    public class Tag : BaseEntity
    {
        public string DisplayName { get; set; }
        public string NormalizedName { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
  