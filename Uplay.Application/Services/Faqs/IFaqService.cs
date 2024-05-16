using Microsoft.AspNetCore.Mvc;
using Uplay.Application.Models;
using Uplay.Application.Models.Faqs;

namespace Uplay.Application.Services.Faqs;

public interface IFaqService : IBaseService
{
    Task<ActionResult<int>> Create(SaveFaqRequest command);
    Task<FaqGetAllResponse> GetAll(PaginationFilter paginationFilter);
    Task<FaqGetResponse> Get(int id);
    Task<int> Delete(int id);
    Task<int> Update(int id, SaveFaqRequest command);
}