using Microsoft.AspNetCore.Mvc;
using Uplay.Application.Models;
using Uplay.Application.Models.Core.Reviews;

namespace Uplay.Application.Services.Reviews;

public interface IReviewService : IBaseService
{
    Task<ActionResult<int>> Create(SaveReviewRequest command);
    Task<ReviewGetAllResponse> GetAll(ReviewFilter filter, PaginationFilter paginationFilter);
}