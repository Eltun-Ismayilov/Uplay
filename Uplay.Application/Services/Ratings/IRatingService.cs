using Microsoft.AspNetCore.Mvc;
using Uplay.Application.Models.Ratings;
using Uplay.Application.Models.Services;

namespace Uplay.Application.Services.Ratings
{
    public interface IRatingService: IBaseService
    {
        Task<ActionResult<int>> Create(SaveRatingRequest command);
    }
}
