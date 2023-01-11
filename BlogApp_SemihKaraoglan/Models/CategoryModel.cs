using BlogApp_SemihKaraoglan.Entity;
using System.ComponentModel.DataAnnotations;

namespace BlogApp_SemihKaraoglan.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(30)]
        [MinLength(3)]
        public string Name { get; set; }
        public string Url { get; set; }
        public bool IsDeleted { get; set; }
        public List<Post> Posts { get; set; }
        public List<Tag> Tags { get; set; }

    }
    public class CategoryDetails
    {
        public Category Category { get; set; }
        public List<Post> Members { get; set; }
        public List<Post> NonMembers { get; set; }
    }

    public class CategoryEditModel
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string[] IdsToAdd { get; set; }
        public string[] IdsToRemove { get; set; }
    }
}
