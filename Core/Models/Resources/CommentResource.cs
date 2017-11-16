namespace DVideo.Core.Models.Resources
{
    public class CommentResource
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }  
        public KeyValuePairResource Video { get; set; }     
        public KeyValuePairResource User { get; set; } 
    }
}