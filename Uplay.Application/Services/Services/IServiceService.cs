using Microsoft.AspNetCore.Mvc;
using Uplay.Application.Models;
using Uplay.Application.Models.Services;

namespace Uplay.Application.Services.Services
{
    public interface IServiceService: IBaseService
    {
        Task<ActionResult<int>> Create(SaveServiceRequest command);
        Task<ServiceGetAllResponse> GetAll(PaginationFilter paginationFilter);
        Task<ServiceGetResponse> Get(int id);
        Task<int> Delete(int id);
        Task<int> Update(int id, SaveServiceRequest command);
    }
}
