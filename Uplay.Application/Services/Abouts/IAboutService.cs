using Microsoft.AspNetCore.Mvc;
using Uplay.Application.Models.Abouts;
using Uplay.Application.Models.Contacts;
using Uplay.Application.Models.Faqs;

namespace Uplay.Application.Services.Abouts
{
    public interface IAboutService : IBaseService
    {
        Task<ActionResult<int>> Create(SaveAboutRequest command);
        Task<AboutGetResponse> Get();
        Task<int> Update(int id, SaveAboutRequest command);

    }
}
