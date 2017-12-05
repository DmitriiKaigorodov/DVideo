using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DVideo.Core;
using DVideo.Core.Models;
using DVideo.Core.Models.Queries;
using DVideo.Core.Models.Resources;
using DVideo.Core.Models.Resources.Queries;
using DVideo.Core.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DVideo.Controllers
{
    [Route("/api/categories")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public CategoriesController(ICategoryRepository categoryRepository, IMapper mapper,
         IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.categoryRepository = categoryRepository;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories(CategoryQueryResource categoryQueryResource)
        {
            var categoryQuery = mapper.Map<CategoryQueryResource, CategoryQuery>(categoryQueryResource);
            var categories = await categoryRepository.GetCategories(categoryQuery);

            var result = mapper.Map<IEnumerable<Category>, IEnumerable<KeyValuePairResource>>(categories);

            return Ok(result);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> AddCategory([FromBody] KeyValuePairResource categoryResource)
        {
            var category = mapper.Map<KeyValuePairResource, Category>(categoryResource);
            categoryRepository.Add(category);
            await unitOfWork.SaveChangesAsync();
            int categoryId = category.Id;

            category = await categoryRepository.GetCategory(categoryId);
            var result = mapper.Map<Category, KeyValuePairResource>(category);
            return Ok(result);
        }

        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] KeyValuePairResource categoryResource)
        {
            var category = await categoryRepository.GetCategory(id);

            if(category == null)
                return NotFound();

            mapper.Map<KeyValuePairResource, Category>(categoryResource, category);
            await unitOfWork.SaveChangesAsync();

            var result = await categoryRepository.GetCategory(id);

            return Ok(mapper.Map<Category, KeyValuePairResource>(result));
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await categoryRepository.GetCategory(id);

            if(category == null)
                return NotFound();

            categoryRepository.Remove(category);
            await unitOfWork.SaveChangesAsync();      

            return Ok();  
        }
    }
}