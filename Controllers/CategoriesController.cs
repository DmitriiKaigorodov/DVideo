using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DVideo.Core.Models;
using DVideo.Core.Models.Queries;
using DVideo.Core.Models.Resources;
using DVideo.Core.Models.Resources.Queries;
using DVideo.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DVideo.Controllers
{
    [Route("/api/categories")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public CategoriesController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.categoryRepository = categoryRepository;

        }

        [HttpGet]
        public  async Task<IActionResult> GetAllCategories(CategoryQueryResource categoryQueryResource)
        {
            var categoryQuery = mapper.Map<CategoryQueryResource,CategoryQuery>(categoryQueryResource);
            var categories = await categoryRepository.GetCategories(categoryQuery);

            var result = mapper.Map<IEnumerable<Category>, IEnumerable<KeyValuePairResource>>(categories);

            return Ok(result);
        }
    }
}