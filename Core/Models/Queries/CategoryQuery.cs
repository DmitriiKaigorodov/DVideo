using System.Linq;

namespace DVideo.Core.Models.Queries
{
    public class CategoryQuery : Query<Category>
    {
        public string Name { get; set; }

        public override IQueryable<Category> ApplyFiltering(IQueryable<Category> items)
        {
            if(!string.IsNullOrWhiteSpace(Name))
            {
                 items = items.Where( 
                    category => 
                    category.Name.Contains(Name)
                );
            }

            return items;
        }

        public override IQueryable<Category> ApplySorting(IQueryable<Category> items)
        {
            throw new System.NotImplementedException();
        }
    }
}