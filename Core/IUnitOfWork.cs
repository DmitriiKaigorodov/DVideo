using System.Threading.Tasks;

namespace DVideo.Core
{
    public interface IUnitOfWork
    {
         Task SaveChangesAsync();
    }
}