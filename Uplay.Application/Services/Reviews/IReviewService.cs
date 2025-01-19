using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Uplay.Application.Models;
using Uplay.Application.Models.Core.Reviews;
using Uplay.Application.Models.Faqs;
using Uplay.Domain.Entities.Models.Landing;

namespace Uplay.Application.Services.Reviews;

public interface IReviewService : IBaseService
{
    Task<ActionResult<int>> Create(SaveReviewRequest command);
    Task<ReviewGetAllResponse> GetAll(ReviewFilter filter, PaginationFilter paginationFilter);
    Task<int> Update(int id, SaveReviewRequest command);

}