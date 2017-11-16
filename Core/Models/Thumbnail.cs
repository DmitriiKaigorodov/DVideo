using System.ComponentModel.DataAnnotations.Schema;
using DVideo.Core.FileStorage;

namespace DVideo.Core.Models
{
    [Table("Thumbnails")]
    public class Thumbnail : UploadedFile
    {

    }
}