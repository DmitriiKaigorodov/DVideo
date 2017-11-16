using System.Collections.Generic;
using System.Threading.Tasks;
using DVideo.Core.Models;
using DVideo.Core.Models.Queries;

namespace DVideo.Core.Repositories
{
    public interface ICategoryRepository
    {
         Task<IEnumerable<Category>> GetCategories(CategoryQuery query);
         Task<Category> GetCategory(int id, bool includeSubcategories = false);
         void Add(Category category);
         void Remove(Category category);
    }
}