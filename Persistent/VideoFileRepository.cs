using System;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using DVideo.Core.FileStorage;
using DVideo.Core.FilesUtils;
using DVideo.Core.Models;
using DVideo.Core.Repositories;
using DVideo.Settings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;


namespace DVideo.Persistent
{
    public class VideoFilesRepository : IVideoFilesRepository
    {
        private readonly DvideoDbContext context;
        private readonly string uploadVideoFolder = "videos";
        private readonly IFileStorage storage;
        private readonly IMapper mapper;
        public VideoFilesRepository(DvideoDbContext context, IFileStorage storage, IMapper mapper)
        {
            this.mapper = mapper;
            this.storage = storage;
            this.context = context;
        }

        public void Add(VideoFile videoFile)
        {
            context.VideoFiles.Add(videoFile);
        }

        public async Task<VideoFile> GetVideoFile(int id)
        {
            return await context.VideoFiles.FindAsync(id);
        }

        public async Task Remove(VideoFile videoFile, bool deleteFromStorage = true)
        {
            context.VideoFiles.Remove(videoFile);

            if (deleteFromStorage)
                await RemoveFromFileStorage(videoFile);
            
            
        }

        public async Task RemoveFromFileStorage(VideoFile videoFile)
        {
            await storage.RemoveFileAsync(videoFile.Path);
        }

        public async Task<VideoFile> SaveInFileStorage(IFormFile uploadedFile, string outputPath)
        {

            var file = await storage.SaveFileAsync(uploadedFile, outputPath);

            var videoFile = mapper.Map<UploadedFile, VideoFile>(file);
            videoFile.DurationInSeconds = VideoFileManager.GetDurationInSeconds(videoFile.Path);
            return videoFile;
        }

    }
}