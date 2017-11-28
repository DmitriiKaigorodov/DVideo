using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DVideo.Core;
using DVideo.Core.Models;
using DVideo.Core.Models.Resources;
using DVideo.Core.Repositories;
using DVideo.Core.Services;
using DVideo.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DVideo.Controllers
{
    [Route("api/auth")]
    public class AuthenticationController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly ISignInService signInService;
        private readonly AuthenticationSettings authenticationSettings;

        public AuthenticationController(
                                         IUserRepository userRepository,
                                         IMapper mapper,
                                         IOptionsSnapshot<AuthenticationSettings> authenticationSettings,
                                         ISignInService signInService)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.signInService = signInService;
            this.authenticationSettings = authenticationSettings.Value;
        }

        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody] UserCredentialsResource userCredentialsResource)
        {          
            var userCredentials = mapper.Map<UserCredentialsResource, UserCredentials>(userCredentialsResource);          
            var user = await userRepository.GetUserByName(userCredentials.Login);
            bool validated = signInService.ValidateCredentialsForUser(user, userCredentials);

            if(!validated)
            {
                return BadRequest("Invalid username or password");
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.Secret));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

             var claims = new[]
            {
                new Claim("name", user.Name),
                new Claim("id", user.Id.ToString(), "int"),
                new Claim("admin", user.IsAdmin.ToString(), "bool"),
                new Claim("email", user.Email)
            };
                    
            var token = new JwtSecurityToken(authenticationSettings.Issuer,
                    authenticationSettings.Audience,
                    claims,
                    expires: DateTime.Now.AddMinutes(authenticationSettings.LifetimeInMinutes),
                    signingCredentials: signingCredentials);

           return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }


        
    }
}