using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DVideo.Core.FileStorage;

namespace DVideo.Core.Models
{
    [Table("VideoFiles")]
    public class VideoFile : UploadedFile
    {
        [Required]
        public int DurationInSeconds { get; set; }
    }
}