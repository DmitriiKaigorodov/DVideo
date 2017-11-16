using System.Linq;

namespace DVideo.Core.Models.Queries
{
    public class VideoQuery : Query<Video>
    {
        public string CategoryName { get; set; }
        public int? MinLength { get; set; }
        public int? MaxLength { get; set; }

        public override IQueryable<Video> ApplyFiltering(IQueryable<Video> items)
        {
            if(!string.IsNullOrWhiteSpace(CategoryName))
            {
                items = items.Where( 
                    video => 
                    video.Categories.Any( cv => cv.Category.Name == CategoryName)
                );
            }           
            if(MinLength.HasValue)
            {
                items = items.Where( 
                    video => video.File.DurationInSeconds >= MinLength.Value
                );
            }
            if(MaxLength.HasValue)
            {
                items = items.Where( 
                    video => video.File.DurationInSeconds <= MaxLength.Value
                );
            }

            return items;
        }

        public override IQueryable<Video> ApplySorting(IQueryable<Video> items)
        {
            throw new System.NotImplementedException();
        }
    }
}