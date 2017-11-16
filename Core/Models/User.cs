using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace DVideo.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public Avatar Avatar { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [StringLength(255)]
        public string Email { get; set; }
        [Required]
        public bool IsAdmin { get; set; }
        [Required]
        public DateTime RegistrationDate { get; set;}
        public DateTime? LastOnlineDate { get; set; }
        public virtual ICollection<Video> PublishedVideos { get; set; }
        public virtual ICollection<UsersLikedVideos> LikedVideos {get; set;}
        public virtual ICollection<UsersDislikedVideos> DislikedVideos {get; set;}
        public virtual ICollection<Comment> Comments { get; set; }


        public User()
        {
            PublishedVideos = new Collection<Video>();
            LikedVideos = new Collection<UsersLikedVideos>();
            DislikedVideos = new Collection<UsersDislikedVideos>();
            Comments = new Collection<Comment>();
            RegistrationDate = DateTime.Now;
        }
    }
}