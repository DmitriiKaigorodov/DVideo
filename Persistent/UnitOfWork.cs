using System.Threading.Tasks;
using DVideo.Core;

namespace DVideo.Persistent
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DvideoDbContext context;
        public UnitOfWork(DvideoDbContext context)
        {
            this.context = context;
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}