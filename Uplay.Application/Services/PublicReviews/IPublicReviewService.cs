using Microsoft.AspNetCore.Mvc;
using Uplay.Application.Models;
using Uplay.Application.Models.PublicReviews;

namespace Uplay.Application.Services.PublicReviews
{
    public interface IPublicReviewService : IBaseService
    {
        Task<ActionResult<int>> Create(SavePublicReviewRequest command);
        Task<PublicReviewGetAllResponse> GetAll(PaginationFilter paginationFilter);
        Task<PublicReviewGetResponse> Get(int id);
        Task<int> Delete(int id);
        Task<int> Update(int id, SavePublicReviewRequest command);
    }
}
