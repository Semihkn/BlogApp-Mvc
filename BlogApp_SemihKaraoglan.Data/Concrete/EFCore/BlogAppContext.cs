using BlogApp_SemihKaraoglan.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp_SemihKaraoglan.Data.Concrete.EFCore
{
    public class BlogAppContext : DbContext
    {
        public BlogAppContext(DbContextOptions options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentReply> CommentReplies { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<PostExtension> PostExtensions { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
               .Entity<Post>()
               .HasMany(p => p.Tags)
               .WithMany(p => p.Posts)
               .UsingEntity<PostTag>(
                   j => j
                       .HasOne(pt => pt.Tag)
                       .WithMany()
                       .HasForeignKey(pt => pt.TagId),
                   j => j
                       .HasOne(pt => pt.Post)
                       .WithMany()
                       .HasForeignKey(pt => pt.PostId));
            modelBuilder
               .Entity<PostCategory>()
               .HasKey(pc => new
               {
                   pc.PostId,
                   pc.CategoryId
               });

        }
    }


}

