using System.Threading.Tasks;
using AutoMapper;
using DVideo.Core;
using DVideo.Core.Models;
using DVideo.Core.Models.Resources;
using DVideo.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DVideo.Controllers
{
    [Route("/api/users")]
    public class UsersController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public UsersController(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.userRepository = userRepository;

        }

        [HttpPost]
        public async Task<IActionResult> Createuser([FromBody] SaveUserResource saveUserResource)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            var user = mapper.Map<SaveUserResource, User>(saveUserResource);
            userRepository.Add(user);
            await unitOfWork.SaveChangesAsync();
            var userResource = mapper.Map<User, UserResource>(user);
            return Ok(userResource);
        }
    }
}