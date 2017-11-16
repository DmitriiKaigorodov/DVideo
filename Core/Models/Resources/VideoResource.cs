using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DVideo.Core.Models.Resources
{
    public class VideoResource
    {
        public int Id { get; set; }
        public string Title { get; set; }  
        public string Description { get; set; }
        public VideoFileResource File { get; set; }
        public UploadedFileResource Thumbnail {get; set;}
        public MainInfoUserResource Author { get; set; }
        public DateTime PublishDate { get; set; }
        public ICollection<KeyValuePairResource> Categories { get; set; } 
        public int Likes { get; set;}
        public int Dislikes { get; set;}

        public VideoResource()
        {
            Categories = new Collection<KeyValuePairResource>();
        }
            
    }
}