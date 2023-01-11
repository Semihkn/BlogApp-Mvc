﻿// <auto-generated />
using System;
using BlogApp_SemihKaraoglan.Data.Concrete.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlogAppSemihKaraoglan.Data.Migrations
{
    [DbContext(typeof(BlogAppContext))]
    [Migration("20230111130935_fixingCate")]
    partial class fixingCate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.1");

            modelBuilder.Entity("BlogApp_SemihKaraoglan.Entity.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("BlogApp_SemihKaraoglan.Entity.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CommentContent")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreateTimeUtc")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PostId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("BlogApp_SemihKaraoglan.Entity.CommentReply", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CommentId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreateTimeUtc")
                        .HasColumnType("TEXT");

                    b.Property<string>("ReplyContent")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.ToTable("CommentReplies");
                });

            modelBuilder.Entity("BlogApp_SemihKaraoglan.Entity.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .HasColumnType("TEXT");

                    b.Property<bool>("CommentEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ContentAbstract")
                        .HasColumnType("TEXT");

                    b.Property<string>("ContentLanguageCode")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreateTimeUtc")
                        .HasColumnType("TEXT");

                    b.Property<string>("HeroImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsFeatured")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsFeedIncluded")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsOriginal")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LastModifiedUtc")
                        .HasColumnType("TEXT");

                    b.Property<string>("OriginLink")
                        .HasColumnType("TEXT");

                    b.Property<string>("PostContent")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("PubDateUtc")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("BlogApp_SemihKaraoglan.Entity.PostCategory", b =>
                {
                    b.Property<int>("PostId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PostId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("PostCategories");
                });

            modelBuilder.Entity("BlogApp_SemihKaraoglan.Entity.PostExtension", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Hits")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Likes")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PostId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PostId")
                        .IsUnique();

                    b.ToTable("PostExtensions");
                });

            modelBuilder.Entity("BlogApp_SemihKaraoglan.Entity.PostTag", b =>
                {
                    b.Property<int>("PostId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TagId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PostId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("PostTags");
                });

            modelBuilder.Entity("BlogApp_SemihKaraoglan.Entity.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("BlogApp_SemihKaraoglan.Entity.Comment", b =>
                {
                    b.HasOne("BlogApp_SemihKaraoglan.Entity.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("BlogApp_SemihKaraoglan.Entity.CommentReply", b =>
                {
                    b.HasOne("BlogApp_SemihKaraoglan.Entity.Comment", "Comment")
                        .WithMany("CommentReplies")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comment");
                });

            modelBuilder.Entity("BlogApp_SemihKaraoglan.Entity.PostCategory", b =>
                {
                    b.HasOne("BlogApp_SemihKaraoglan.Entity.Category", "Category")
                        .WithMany("PostCategory")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlogApp_SemihKaraoglan.Entity.Post", "Post")
                        .WithMany("PostCategory")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("BlogApp_SemihKaraoglan.Entity.PostExtension", b =>
                {
                    b.HasOne("BlogApp_SemihKaraoglan.Entity.Post", "Post")
                        .WithOne("PostExtension")
                        .HasForeignKey("BlogApp_SemihKaraoglan.Entity.PostExtension", "PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("BlogApp_SemihKaraoglan.Entity.PostTag", b =>
                {
                    b.HasOne("BlogApp_SemihKaraoglan.Entity.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlogApp_SemihKaraoglan.Entity.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("BlogApp_SemihKaraoglan.Entity.Category", b =>
                {
                    b.Navigation("PostCategory");
                });

            modelBuilder.Entity("BlogApp_SemihKaraoglan.Entity.Comment", b =>
                {
                    b.Navigation("CommentReplies");
                });

            modelBuilder.Entity("BlogApp_SemihKaraoglan.Entity.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("PostCategory");

                    b.Navigation("PostExtension");
                });
#pragma warning restore 612, 618
        }
    }
}