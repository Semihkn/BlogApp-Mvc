using BlogApp_SemihKaraoglan.Entity;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BlogApp_SemihKaraoglan.Models
{
    public class PostModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title Required!")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Beetwen 5-50 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Content Required!")]
        [StringLength(1500, MinimumLength = 25, ErrorMessage = "Beetwen 25-1500 characters.")]
        public string PostContent { get; set; }
        public string HeroImageUrl { get; set; }
        public bool IsDeleted { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public string Author { get; set; }
        public bool CommentEnabled { get; set; }


        [AllowNull]
        public Category SelectedCategory { get; set; } = null!;
        public Tag SelectedTags { get; set; } = null!;
        public DateTime CreateTimeUtc { get; set; }= DateTime.Now;
    }
}
