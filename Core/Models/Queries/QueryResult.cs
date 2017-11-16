using System.Collections.Generic;

namespace DVideo.Core.Models.Queries
{
    public class QueryResult<T>
    {
        public int TotalItems { get; set; }
        public IEnumerable<T> Entries { get; set; }
    }
}