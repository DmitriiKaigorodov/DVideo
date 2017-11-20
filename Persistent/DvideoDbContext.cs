using DVideo.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DVideo.Persistent
{
    public class DvideoDbContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<VideoFile> VideoFiles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UsersLikedVideos> WatchedVideos { get; set; }
        public DbSet<UsersDislikedVideos> UploadedVideos { get; set; }
        public DbSet<CategoryVideo> CategoryVideo { get; set; }
        public DbSet<Thumbnail> Thumbnails { get; set; }
        public DbSet<Avatar> Avatars { get; set; }

        public DvideoDbContext(DbContextOptions<DvideoDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryVideo>()
            .HasKey( cv => new { cv.CategoryId, cv.VideoId});

             modelBuilder.Entity<CategoryVideo>()
             .HasOne( cv => cv.Category)
             .WithMany( c => c.Videos).HasForeignKey( cv => cv.CategoryId);
             
             modelBuilder.Entity<CategoryVideo>()
             .HasOne( cv => cv.Video)
             .WithMany( c => c.Categories).HasForeignKey( cv => cv.VideoId);

             modelBuilder.Entity<UsersLikedVideos>()
             .HasKey( ulv => new { ulv.UserId, ulv.VideoId} );

             modelBuilder.Entity<UsersLikedVideos>()
             .HasOne( ulv => ulv.User).WithMany( user => user.LikedVideos)
             .HasForeignKey(ulv => ulv.UserId).OnDelete(DeleteBehavior.Restrict);

             modelBuilder.Entity<UsersLikedVideos>()
             .HasOne( ulv => ulv.Video).WithMany( video => video.UsersLiked)
             .HasForeignKey(ulv => ulv.VideoId).OnDelete(DeleteBehavior.Restrict);

             modelBuilder.Entity<UsersDislikedVideos>()
             .HasKey( ulv => new { ulv.UserId, ulv.VideoId} );

             modelBuilder.Entity<UsersDislikedVideos>()
             .HasOne( ulv => ulv.User).WithMany( user => user.DislikedVideos)
             .HasForeignKey(ulv => ulv.UserId).OnDelete(DeleteBehavior.Restrict);

             modelBuilder.Entity<UsersDislikedVideos>()
             .HasOne( ulv => ulv.Video).WithMany( video => video.UsersDisliked)
             .HasForeignKey(ulv => ulv.VideoId).OnDelete(DeleteBehavior.Restrict);
             
             modelBuilder.Entity<User>().HasMany( user => user.PublishedVideos)
             .WithOne( v => v.Author).HasForeignKey( v => v.AuthorId);

             modelBuilder.Entity<Comment>()
             .HasOne( cm => cm.User).WithMany( user => user.Comments)
             .HasForeignKey( cm => cm.UserId).OnDelete(DeleteBehavior.Restrict);

             modelBuilder.Entity<Comment>()
             .HasOne( cm => cm.Video).WithMany( video => video.Comments)
             .HasForeignKey( cm => cm.VideoId).OnDelete(DeleteBehavior.Restrict);


        }
    }
}