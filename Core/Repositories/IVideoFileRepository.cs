using DVideo.Core.Models;
using DVideo.Core.FileStorage;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace DVideo.Core.Repositories
{

    public interface IVideoFilesRepository
    {
         Task<VideoFile> SaveInFileStorage(IFormFile videoFile, string outputPath);
         Task RemoveFromFileStorage(VideoFile videoFile);
         void Add(VideoFile videoFile);
         Task Remove(VideoFile videoFile, bool deleteFromStorage = true);
         Task<VideoFile> GetVideoFile(int id);
    }
}