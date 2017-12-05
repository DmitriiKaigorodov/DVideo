using System;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using DVideo.Core;
using DVideo.Core.Models;
using DVideo.Core.Models.Resources;
using DVideo.Core.Repositories;
using DVideo.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DVideo.Controllers
{
    [Route("/api/videos/videofile")]
    public class VideoFileController : Controller
    {
        private readonly IVideosRepository videoRepository;
        private readonly IVideoFilesRepository videoFileRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly  VideoSettings videoSettings;

        public VideoFileController(
            IVideosRepository videoRepository, 
            IVideoFilesRepository videoFileRepository,
            IUnitOfWork unitOfWork,
            IOptionsSnapshot<VideoSettings> videoSettingsSnapshot,
            IMapper mapper          
         )
        {
            this.videoRepository = videoRepository;
            this.videoFileRepository = videoFileRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.videoSettings = videoSettingsSnapshot.Value;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
               
            if(file.Length == 0)
                return BadRequest("Video file is invalid");

            var validationResult = videoSettings.VideoFileSettings.Validate(file);

            if(validationResult != FileValidationResult.Ok)
            {
                string errorDescription = videoSettings.VideoFileSettings.ErrorsDescriptions[validationResult];
                return BadRequest(errorDescription);
            }

            string fileExtention = Path.GetExtension(file.FileName);
            string relativeOutputPath  = Path.Combine("uploads", $"videos", $"video_{DateTime.Now.Ticks}{fileExtention}");
                
            var videoFile = await videoFileRepository.SaveInFileStorage(file, relativeOutputPath);

            videoFileRepository.Add(videoFile);
            
            await unitOfWork.SaveChangesAsync();

            var result = mapper.Map<VideoFile, VideoFileResource>(videoFile);
            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFile(int id)
        {
            var videoFile =  await videoFileRepository.GetVideoFile(id);

            if(videoFile == null)
                return NotFound();
                
            await videoFileRepository.Remove(videoFile);
            await unitOfWork.SaveChangesAsync();
            return Ok();
        }
        

        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> UpdateVideoFile(int id,[FromBody] SaveVideoFileResource videoFileResource)
        {

            var videoFile =  await videoFileRepository.GetVideoFile(id);

            if(videoFile == null)
                return NotFound();
            
            mapper.Map<SaveVideoFileResource, VideoFile>(videoFileResource, videoFile);
            await unitOfWork.SaveChangesAsync();

            return Ok();
        }



    }
}