namespace DVideo.Core.Models.Resources.Queries
{
    public class VideoQueryResource : QueryResource
    {
        public string CategoryName { get; set; }
        public int? MinLength { get; set; }
        public int? MaxLength { get; set; } 

    }
}