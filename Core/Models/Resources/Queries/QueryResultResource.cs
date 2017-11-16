using System.Collections.Generic;

namespace DVideo.Core.Models.Resources.Queries
{
    public class QueryResultResource<T>
    {
        public int TotalItems { get; set; }
        public IEnumerable<T> Entries { get; set; }
    }
}