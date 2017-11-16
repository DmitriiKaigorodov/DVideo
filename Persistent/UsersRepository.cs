using System.Collections.Generic;
using System.Threading.Tasks;
using DVideo.Core.Models;
using DVideo.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DVideo.Persistent
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DvideoDbContext context;
        public UsersRepository(DvideoDbContext context)
        {
            this.context = context;

        }
        public void Add(User user)
        {
            context.Users.Add(user);
        }

        public async Task<User> GetUser(int id, bool includeRelated = true)
        {
            if(!includeRelated)
            {
              return await context.Users.FindAsync(id);
            }

            return await context.Users.Include(u => u.PublishedVideos)
                    .Include(u => u.LikedVideos).Include(u => u.DislikedVideos)
                    .SingleOrDefaultAsync( u => u.Id == id);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await context.Users.Include(u => u.PublishedVideos)
                    .Include(u => u.LikedVideos).Include(u => u.DislikedVideos)
                    .ToListAsync();
        }

        public void Remove(User user)
        {
            context.Users.Remove(user);
        }
    }
}