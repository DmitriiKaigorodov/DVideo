using System.Collections.Generic;
using System.Threading.Tasks;
using DVideo.Core.Models;

namespace DVideo.Core.Repositories
{
    public interface IUserRepository
    {
         Task<IEnumerable<User>> GetUsers();
         Task<User> GetUser(int id, bool includeRelated = true);
         Task<User> GetUserByName(string name, bool includeRelated = true);
         void Add(User user);
         void Remove(User user);
    }
}