using System.Threading.Tasks;
using DVideo.Core.Models;

namespace DVideo.Core.Services
{
    public interface ISignInService
    {
         bool ValidateCredentialsForUser(User user, UserCredentials authRequest);
    }
}