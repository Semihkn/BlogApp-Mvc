using BlogApp_SemihKaraoglan.Entity;

namespace BlogApp_SemihKaraoglan.ViewModels
{
    public class PostViewModel
    {
        public PageInfo PageInfo { get; set; } = null!;
        public List<Post> Posts { get; set; } = null!;
    }
    public class PageInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public string? CurrentCategory { get; set; }

        public int TotalPages()
        {
            return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
        }
    }
}
