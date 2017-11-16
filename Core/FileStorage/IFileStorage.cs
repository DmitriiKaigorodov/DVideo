using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DVideo.Core.FileStorage
{
    public interface IFileStorage
    {
         Task<UploadedFile> SaveFileAsync(IFormFile uploadedFile, string outputPath);
         Task RemoveFileAsync(string outputPath);
         
    }
}