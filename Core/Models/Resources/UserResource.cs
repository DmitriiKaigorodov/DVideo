using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DVideo.Core.Models.Resources
{
    public class UserResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime RegistrationDate { get; set;}
        public DateTime? LastOnlineDate { get; set; }
        public virtual ICollection<MainInfoVideoResourse> PublishedVideos { get; set; }
        public virtual ICollection<MainInfoVideoResourse> LikedVideos {get; set;}
        public virtual ICollection<MainInfoVideoResourse> DislikedVideos {get; set;}
        public virtual ICollection<CommentResource> Comments { get; set; }


        public UserResource()
        {
            PublishedVideos = new Collection<MainInfoVideoResourse>();
            LikedVideos = new Collection<MainInfoVideoResourse>();
            DislikedVideos = new Collection<MainInfoVideoResourse>();
            Comments = new Collection<CommentResource>();
        }       
    }
}