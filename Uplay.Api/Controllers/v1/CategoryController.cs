using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Uplay.Api.Contracts;
using Uplay.Application.Models;
using Uplay.Application.Models.Categories;
using Uplay.Application.Models.Faqs;
using Uplay.Application.Services.Categories;
using Uplay.Application.Services.Partners;

namespace Uplay.Api.Controllers.v1
{
    [AllowAnonymous]
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost(ApiRoutes.CategoryRoute.Create)]
        public async Task<ActionResult<int>> Create([FromForm] SaveCategoryRequest command)
        {
            var data = await _categoryService.Create(command);
            return Ok(data.Value);
        }

        [HttpGet(ApiRoutes.CategoryRoute.GetAll)]
        public async Task<ActionResult<CategoryGetAllResponse>> GetAll()
        {
            return Ok(await _categoryService.GetAll());
        }
    }
}
