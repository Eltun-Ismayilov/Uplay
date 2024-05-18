using Microsoft.AspNetCore.Mvc;
using Uplay.Application.Models;
using Uplay.Application.Models.Core.Feedbacks;
using Uplay.Application.Models.Feedbacks;

namespace Uplay.Application.Services.Feedbacks;

public interface IFeedbackService : IBaseService
{
    Task<ActionResult<int>> Create(SaveFeedbackRequest command);
    Task<FeedbackGetAllResponse> GetAll(int id, PaginationFilter paginationFilter);
}