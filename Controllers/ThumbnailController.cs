using System;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using DVideo.Core;
using DVideo.Core.FileStorage;
using DVideo.Core.Models;
using DVideo.Core.Models.Resources;
using DVideo.Core.Repositories;
using DVideo.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DVideo.Controllers
{
    [Route("/api/videos/thumbnail")]
    public class ThumbnailController : Controller
    {

        private readonly IThumbnailsRepository thumbnailRepository;
        private readonly IVideosRepository videoRepository;
        private readonly string thumbnaillUploadFolder = "thumbnails";
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ThumbnailSettings thumbnailSettings;
        public ThumbnailController(IThumbnailsRepository thumbnailRepository,
        IVideosRepository videoRepository, IUnitOfWork unitOfWork, IMapper mapper, 
        IOptionsSnapshot<ThumbnailSettings> thumbnailSettings)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.videoRepository = videoRepository;
            this.thumbnailRepository = thumbnailRepository;
            this.thumbnailSettings = thumbnailSettings.Value;

        }
    [HttpPost]
    public async Task<IActionResult> UploadThumbnail(IFormFile file)
    {
        var validationResult = thumbnailSettings.Validate(file);
        
        if(validationResult != FileValidationResult.Ok)
        {
            string errorDescription = thumbnailSettings.ErrorsDescriptions[validationResult];
            return BadRequest(errorDescription);
        }

        string fileExtention = Path.GetExtension(file.FileName);
        string relativeOutputPath = Path.Combine("uploads", $"thumbnails", $"thumbnail_{DateTime.Now.Ticks}{fileExtention}");
        var thumbnail = await thumbnailRepository.SaveInFileStorageAsync(file, relativeOutputPath);
        thumbnailRepository.Add(thumbnail);
        await unitOfWork.SaveChangesAsync();
        var result = mapper.Map<Thumbnail, UploadedFileResource>(thumbnail);

        return Ok(result);
    }

}
}