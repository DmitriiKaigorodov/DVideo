namespace DVideo.Core.Models.Resources
{
    public class SaveCommentResource
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }  
        public int VideoId { get; set; }     
        public int UserId { get; set; } 
    }
}