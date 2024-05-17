using Microsoft.AspNetCore.Mvc;
using Uplay.Application.Models;
using Uplay.Application.Models.Partners;

namespace Uplay.Application.Services.Partners;

public interface IPartnerService: IBaseService
{
    Task<ActionResult<int>> Create(SavePartnerRequest command);
    Task<PartnerGetAllResponse> GetAll(PaginationFilter paginationFilter);
    Task<PartnerGetResponse> Get(int id);
    Task<int> Delete(int id);
    Task<int> Update(int id, SavePartnerRequest command);
}