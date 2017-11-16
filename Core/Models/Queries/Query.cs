using System.Linq;

namespace DVideo.Core.Models.Queries
{
    public abstract class Query<T>
    {
        public int? Page { get; set; }
        public int? Limit { get; set; }
        public string SortingCollumn { get; set;}
        public abstract IQueryable<T> ApplyFiltering(IQueryable<T> items);
        public abstract IQueryable<T> ApplySorting(IQueryable<T> items);
        public  IQueryable<T> ApplyPaging(IQueryable<T> items)
        {
            if(!Page.HasValue && !Limit.HasValue)
                return items;

            return items.Skip( (Page.Value - 1) * Limit.Value).Take(Limit.Value);
        }
    }
}