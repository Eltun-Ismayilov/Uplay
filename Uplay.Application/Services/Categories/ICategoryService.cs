using Microsoft.AspNetCore.Mvc;
using Uplay.Application.Models;
using Uplay.Application.Models.Categories;
using Uplay.Application.Models.Faqs;
using Uplay.Application.Models.Partners;

namespace Uplay.Application.Services.Categories
{
    public interface ICategoryService: IBaseService
    {
        Task<ActionResult<int>> Create(SaveCategoryRequest command);
        Task<CategoryGetAllResponse> GetAll();
        Task<int> Update(int categoryId, SaveCategoryRequest command);
    }
}
