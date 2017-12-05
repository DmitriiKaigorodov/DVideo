using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using DVideo.Core;
using DVideo.Core.FileStorage;
using DVideo.Core.Models;
using DVideo.Core.Models.Queries;
using DVideo.Core.Models.Resources;
using DVideo.Core.Models.Resources.Queries;
using DVideo.Core.Repositories;
using DVideo.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DVideo.Controllers
{
    [Route("api/videos")]
    public class VideoController : Controller
    {
        private readonly IVideosRepository videoRepository;

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly VideoSettings videoSettings;
        public VideoController(
         IVideosRepository videoRepository, 
         IUnitOfWork unitOfWork,
         IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.videoRepository = videoRepository;

        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CreateVideo([FromBody] SaveVideoResource video)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            var newVideo = mapper.Map<SaveVideoResource, Video>(video);
            videoRepository.Add(newVideo);

            await unitOfWork.SaveChangesAsync();
            int videoId = newVideo.Id;
            newVideo = await videoRepository.GetVideo(videoId);
            var result = mapper.Map<Video, VideoResource>(newVideo);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVideo(int id)
        {
            var video = await videoRepository.GetVideo(id);

            if(video == null) 
                return NotFound();

            var result = mapper.Map<Video, VideoResource>(video);
            return Ok(result);          
        }


        [HttpGet]
        public async Task<IActionResult> GetVideos(VideoQueryResource videoQueryResource)
        {
            var videoQuery = mapper.Map<VideoQueryResource, VideoQuery>(videoQueryResource);
            var videos = await videoRepository.GetVideos(videoQuery);

            var result = mapper.Map<QueryResult<Video>, QueryResultResource<MainInfoVideoResourse>>(videos);
            return Ok(result);
        }

        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> UpdateVideo(int id, [FromBody] SaveVideoResource videoResource)
        {
            var video = await videoRepository.GetVideo(id);

            if(video == null) 
                return NotFound();

             mapper.Map<SaveVideoResource, Video>(videoResource, video);

            await unitOfWork.SaveChangesAsync();

            video = await videoRepository.GetVideo(id);
            var result = mapper.Map<Video, VideoResource>(video);
            return Ok(result);

        }

        
    }
}