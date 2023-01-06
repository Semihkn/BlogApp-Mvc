using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp_SemihKaraoglan.Entity
{
    public class CommentReply : BaseEntity
    {
        public string ReplyContent { get; set; }
        public DateTime CreateTimeUtc { get; set; }
        public int CommentId { get; set; }
        public Comment Comment { get; set; }
    }
}
