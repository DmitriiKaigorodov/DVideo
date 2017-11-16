using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DVideo.Core.Models
{
    [Table("Comments")]
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        public int VideoId { get; set; }
        public Video Video { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}