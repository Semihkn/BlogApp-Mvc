using BlogApp_SemihKaraoglan.Entity;

namespace BlogApp_SemihKaraoglan.Models
{
    public class PostDetailModel
    {
        public Post Post { get; set; } = null!;
        public Category Category { get; set; } = null!;
        public Comment Comment { get; set; } = null!;
        public CommentReply CommentReply { get; set; } = null!;

    }
}
