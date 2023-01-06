using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp_SemihKaraoglan.Entity
{
    public class Comment : BaseEntity
    {      
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public DateTime CreateTimeUtc { get; set; }
        public string CommentContent { get; set; }
        public bool IsApproved { get; set; }
        public  Post Post { get; set; }
        public  ICollection<CommentReply> CommentReplies { get; set; }
    }
}
