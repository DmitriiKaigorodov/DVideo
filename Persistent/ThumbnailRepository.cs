using System.Threading.Tasks;
using AutoMapper;
using DVideo.Core.FileStorage;
using DVideo.Core.Models;
using DVideo.Core.Repositories;
using Microsoft.AspNetCore.Http;

namespace DVideo.Persistent
{
    public class ThumbnailsRepository : IThumbnailsRepository
    {
        private readonly string thumbnailsUploadFolder = "thumbnails";
        private readonly DvideoDbContext context;
        private readonly IFileStorage fileStorage;
        private readonly IMapper mapper;
        public ThumbnailsRepository(DvideoDbContext context, IFileStorage fileStorage, IMapper mapper)
        {
            this.mapper = mapper;
            this.fileStorage = fileStorage;
            this.context = context;

        }

        public void Add(Thumbnail thumbnail)
        {
            context.Thumbnails.Add(thumbnail);
        }


        public async void Remove(Thumbnail thumbnail, bool removeFromStorage = true)
        {
            context.Thumbnails.Remove(thumbnail);

            if (removeFromStorage)
                await RemoveFileFromStorage(thumbnail);
        }

        public async Task RemoveFileFromStorage(Thumbnail thumbnail)
        {
            await fileStorage.RemoveFileAsync(thumbnail.Path);
        }

        public async Task<Thumbnail> SaveInFileStorageAsync(IFormFile uploadedFile, string outputPath)
        {
            var thumbnail = await fileStorage.SaveFileAsync(uploadedFile, outputPath);
            return mapper.Map<UploadedFile, Thumbnail>(thumbnail);
        }
    }
}