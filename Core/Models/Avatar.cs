using System.ComponentModel.DataAnnotations.Schema;
using DVideo.Core.FileStorage;

namespace DVideo.Core.Models
{
    [Table("Avatars")]
    public class Avatar : UploadedFile
    {
        public User User { get; set; }   
        public int UserId { get; set; }
    }
}