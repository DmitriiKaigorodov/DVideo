using System.ComponentModel.DataAnnotations;

namespace DVideo.Core.FileStorage
{
    public  class UploadedFile
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Path { get; set; }
        [Required]
        public string Url { get; set; }
    }
}