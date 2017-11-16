using System.Threading.Tasks;
using DVideo.Core.Models;
using Microsoft.AspNetCore.Http;

namespace DVideo.Core.Repositories
{
    public interface IThumbnailsRepository
    {
         void Add(Thumbnail thumbnail);
         Task<Thumbnail> SaveInFileStorageAsync(IFormFile videoFile, string outputPath);
         Task RemoveFileFromStorage(Thumbnail thumbnail);
         void Remove(Thumbnail thumbnail, bool removeFromStorage = true);         
    }
}