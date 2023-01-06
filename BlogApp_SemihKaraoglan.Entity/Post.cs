using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp_SemihKaraoglan.Entity
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }
        public int UserId { get; set; }
        //public string Slug { get; set; }
        public string Author { get; set; }
        public string PostContent { get; set; }
        public bool CommentEnabled { get; set; }
        public DateTime CreateTimeUtc { get; set; }
        public string ContentAbstract { get; set; }
        public string ContentLanguageCode { get; set; }
        public bool IsFeedIncluded { get; set; }
        public DateTime? PubDateUtc { get; set; }
        public DateTime? LastModifiedUtc { get; set; }
        public bool IsPublished { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsOriginal { get; set; }
        public string OriginLink { get; set; }
        public string HeroImageUrl { get; set; }

        public bool IsFeatured { get; set; }
       //public int HashCheckSum { get; set; }

        public PostExtension PostExtension { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<PostCategory> PostCategory { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}
