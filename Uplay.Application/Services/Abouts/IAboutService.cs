using Microsoft.AspNetCore.Mvc;
using Uplay.Application.Models.Abouts;

namespace Uplay.Application.Services.Abouts
{
    public interface IAboutService :IBaseService
    {
        Task<ActionResult<int>> Create(SaveAboutRequest command);
    }
}
