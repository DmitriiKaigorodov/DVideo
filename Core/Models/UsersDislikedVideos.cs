namespace DVideo.Core.Models
{
    public class UsersDislikedVideos
    {
        public int VideoId { get; set; }
        public Video Video { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}