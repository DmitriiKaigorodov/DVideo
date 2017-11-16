using System.Collections.Generic;
using System.Threading.Tasks;
using DVideo.Core.Models;
using DVideo.Core.Models.Queries;

namespace DVideo.Core.Repositories
{
    public interface IVideosRepository
    {
         Task<QueryResult<Video>> GetVideos(VideoQuery filter);
         Task<Video> GetVideo(int id, bool includeRelated = false);
         void Add(Video video);
         void Remove(Video video);
         Task<IEnumerable<Video>> GetVideosForCategory(Category category, bool includeRelated = false);

    }
}