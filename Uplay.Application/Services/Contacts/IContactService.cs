using Microsoft.AspNetCore.Mvc;
using Uplay.Application.Models;
using Uplay.Application.Models.Contacts;
using Uplay.Application.Models.Faqs;
using Uplay.Domain.Entities.Models.Landing;

namespace Uplay.Application.Services.Contacts;

public interface IContactService: IBaseService
{
    Task<ActionResult<int>> Create(SaveContactRequest command);
    Task<ContactGetAllResponse> GetAll(PaginationFilter paginationFilter);
    Task<ContactGetResponse> Get(int id);
}