using System;
using System.Threading.Tasks;
using DVideo.Core.Extentions;
using DVideo.Core.Models;
using DVideo.Core.Repositories;
using DVideo.Core.Services;


namespace DVideo.Services
{
    public class SignInService : ISignInService
    {

        public  bool ValidateCredentialsForUser(User user, UserCredentials authRequest)
        {
            if(user == null)
                return false;
        
            var enteredPasswordHash = authRequest.Password.ToSha256();          
            return enteredPasswordHash.Equals(user.Password, StringComparison.Ordinal);
        }
    }
}