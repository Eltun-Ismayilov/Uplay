using Microsoft.AspNetCore.Mvc;
using Uplay.Application.Extensions;
using Uplay.Application.Models;
using Uplay.Application.Models.Core.Feedbacks;
using Uplay.Application.Models.Feedbacks;

namespace Uplay.Application.Services.Feedbacks;

public interface IFeedbackService : IBaseService
{
    Task<ActionResult<int>> Create(SaveFeedbackRequest command);
    Task<FeedbackGetAllResponse> GetAll(FeedbackFilter filter, PaginationFilter paginationFilter);
    Task<ActionResult<int>> CreateFeedbackType(SaveFeedbackTypeRequest command);
    Task<ActionResult<int>> DeleteFeedbackType(int feedbackTypeId);
    Task<ActionResult<int>> UpdateFeedbackType(int feedbackTypeId, SaveFeedbackTypeRequest request);
    Task<FeedbackTypeGetAllReponse> GetAllFeedbackTypes(PaginationFilter paginationFilter);
    CommonStatistics GetCommonStatistics(FilterQuery filter);
}