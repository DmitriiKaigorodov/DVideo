using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DVideo.Core.Models
{
    [Table("Videos")]
    public class Video
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Title { get; set; }  
        [Required]
        public string Description { get; set; }
        public int? ThumbnailId { get; set; }
        public Thumbnail Thumbnail { get; set;}
        public int FileId { get; set; }
        public VideoFile File { get; set; }
        [Required]
        public User Author { get; set; }
        [Required]
        public DateTime PublishDate { get; set; }
        public int AuthorId { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<CategoryVideo> Categories { get; set; } 
        public virtual ICollection<UsersLikedVideos> UsersLiked { get; set; }
        public virtual ICollection<UsersDislikedVideos> UsersDisliked { get; set; }

        public Video()
        {
            Categories = new Collection<CategoryVideo>();
            Comments = new Collection<Comment>();
            UsersLiked = new Collection<UsersLikedVideos>();
            UsersDisliked = new Collection<UsersDislikedVideos>();
        }
    }
}