using Uplay.Application.Models.PublicReviews;
using Uplay.Application.Models.RatingBranch;

namespace Uplay.Application.Services.RatingBranchs
{
    public interface IRatingBranchService: IBaseService
    {
        Task<RatingBranchGetResponse> Get(int branchId);
    }
}
