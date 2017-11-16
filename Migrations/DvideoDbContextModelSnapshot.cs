﻿// <auto-generated />
using DVideo.Persistent;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace DVideo.Migrations
{
    [DbContext(typeof(DvideoDbContext))]
    partial class DvideoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DVideo.Core.Models.Avatar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Url")
                        .IsRequired();

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Avatars");
                });

            modelBuilder.Entity("DVideo.Core.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int?>("ParentId");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("DVideo.Core.Models.CategoryVideo", b =>
                {
                    b.Property<int>("CategoryId");

                    b.Property<int>("VideoId");

                    b.HasKey("CategoryId", "VideoId");

                    b.HasIndex("VideoId");

                    b.ToTable("CategoryVideo");
                });

            modelBuilder.Entity("DVideo.Core.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Text")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<int>("UserId");

                    b.Property<int>("VideoId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("VideoId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("DVideo.Core.Models.Thumbnail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Url")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Thumbnails");
                });

            modelBuilder.Entity("DVideo.Core.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<bool>("IsAdmin");

                    b.Property<DateTime?>("LastOnlineDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<DateTime>("RegistrationDate");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DVideo.Core.Models.UsersDislikedVideos", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("VideoId");

                    b.HasKey("UserId", "VideoId");

                    b.HasIndex("VideoId");

                    b.ToTable("UploadedVideos");
                });

            modelBuilder.Entity("DVideo.Core.Models.UsersLikedVideos", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("VideoId");

                    b.HasKey("UserId", "VideoId");

                    b.HasIndex("VideoId");

                    b.ToTable("WatchedVideos");
                });

            modelBuilder.Entity("DVideo.Core.Models.Video", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthorId");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int>("FileId");

                    b.Property<DateTime>("PublishDate");

                    b.Property<int?>("ThumbnailId");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("FileId");

                    b.HasIndex("ThumbnailId");

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("DVideo.Core.Models.VideoFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DurationInSeconds");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Url")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("VideoFiles");
                });

            modelBuilder.Entity("DVideo.Core.Models.Avatar", b =>
                {
                    b.HasOne("DVideo.Core.Models.User", "User")
                        .WithOne("Avatar")
                        .HasForeignKey("DVideo.Core.Models.Avatar", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DVideo.Core.Models.Category", b =>
                {
                    b.HasOne("DVideo.Core.Models.Category", "Parent")
                        .WithMany("Subcategories")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("DVideo.Core.Models.CategoryVideo", b =>
                {
                    b.HasOne("DVideo.Core.Models.Category", "Category")
                        .WithMany("Videos")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DVideo.Core.Models.Video", "Video")
                        .WithMany("Categories")
                        .HasForeignKey("VideoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DVideo.Core.Models.Comment", b =>
                {
                    b.HasOne("DVideo.Core.Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DVideo.Core.Models.Video", "Video")
                        .WithMany("Comments")
                        .HasForeignKey("VideoId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DVideo.Core.Models.UsersDislikedVideos", b =>
                {
                    b.HasOne("DVideo.Core.Models.User", "User")
                        .WithMany("DislikedVideos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DVideo.Core.Models.Video", "Video")
                        .WithMany("UsersDisliked")
                        .HasForeignKey("VideoId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DVideo.Core.Models.UsersLikedVideos", b =>
                {
                    b.HasOne("DVideo.Core.Models.User", "User")
                        .WithMany("LikedVideos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DVideo.Core.Models.Video", "Video")
                        .WithMany("UsersLiked")
                        .HasForeignKey("VideoId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("DVideo.Core.Models.Video", b =>
                {
                    b.HasOne("DVideo.Core.Models.User", "Author")
                        .WithMany("PublishedVideos")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DVideo.Core.Models.VideoFile", "File")
                        .WithMany()
                        .HasForeignKey("FileId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DVideo.Core.Models.Thumbnail", "Thumbnail")
                        .WithMany()
                        .HasForeignKey("ThumbnailId");
                });
#pragma warning restore 612, 618
        }
    }
}
