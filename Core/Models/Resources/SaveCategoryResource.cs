namespace DVideo.Core.Models.Resources
{
    public class SaveCategoryResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
    }
}