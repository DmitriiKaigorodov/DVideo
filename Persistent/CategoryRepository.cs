using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DVideo.Core.Models;
using DVideo.Core.Models.Queries;
using DVideo.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DVideo.Persistent
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DvideoDbContext context;
        public CategoryRepository(DvideoDbContext context)
        {
            this.context = context;

        }

        public void Add(Category category)
        {
            context.Categories.Add(category);
        }

        public async Task<IEnumerable<Category>> GetCategories(CategoryQuery query)
        {
            var categories =  context.Categories.AsQueryable();

           /* if(!string.IsNullOrWhiteSpace(query.Name))
                categories = categories.Where( c => c.Name.Contains(query.Name));*/

            categories = query.ApplyFiltering(categories);

             return await categories.ToListAsync();
        }

        public async Task<Category> GetCategory(int id)
        {           
            return await context.Categories.SingleOrDefaultAsync( c => c.Id == id);
        }

        public void Remove(Category category)
        {
             context.Categories.Remove(category);
        }
    }
}