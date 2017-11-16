using System;
using System.IO;
using System.Threading.Tasks;
using DVideo.Core.FileStorage;
using DVideo.Core.FilesUtils;
using DVideo.Core.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace DVideo.Persistent.LocalFileStorage
{
    public class LocalFileStorage : IFileStorage
    {
        private readonly IHostingEnvironment hostingEnvironment;
        public LocalFileStorage(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;

        }
        public void PrepareDirectoryForFile(string filePath)
        {

            string fileDirectoryPath = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(fileDirectoryPath))
            {
                Directory.CreateDirectory(fileDirectoryPath);
            }
            else if(File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public  async Task RemoveFileAsync(string uploadDirectoryName)
        {
             await Task.Run(() =>
            {
                string videoFilePath = Path.Combine(hostingEnvironment.WebRootPath, uploadDirectoryName);

                if (File.Exists(videoFilePath))
                    File.Delete(videoFilePath);
            });
        }
        public async Task<UploadedFile> SaveFileAsync(IFormFile uploadedFile, string outputPath)
        {
            string fullOutputPath =  Path.Combine(hostingEnvironment.WebRootPath, outputPath);
            PrepareDirectoryForFile(fullOutputPath);

            using (FileStream fileStream = new FileStream(fullOutputPath, FileMode.Create))
            {
                await uploadedFile.CopyToAsync(fileStream);
            }
        
            var uriBuilder = new UriBuilder();
            uriBuilder.Path = outputPath;
            
            
            UploadedFile fileEnitity = new UploadedFile
            {
                Path = fullOutputPath,
                Url = outputPath.Replace(Path.DirectorySeparatorChar, '/')            
            };

            return fileEnitity;
        }
    }
}