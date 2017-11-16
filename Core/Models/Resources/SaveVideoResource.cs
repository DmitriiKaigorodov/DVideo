using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DVideo.Core.Models.Resources
{
    public class SaveVideoResource
    {
        public int Id { get; set; }
        public string Title { get; set; }  
        public string Description { get; set; }
        public int FileId { get; set; }
        public int? ThumbnailId { get; set; }
        public int AuthorId { get; set; }
        public DateTime PublishDate { get; set; }
        public ICollection<int> Categories { get; set; } 

        public SaveVideoResource()
        {
            PublishDate = DateTime.Now;
            Categories = new Collection<int>();
        }       
    }
}