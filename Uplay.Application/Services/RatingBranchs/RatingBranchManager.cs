using AutoMapper;
using Uplay.Application.Exceptions;
using Uplay.Application.Models.RatingBranch;
using Uplay.Application.Models.RatingBranchs;
using Uplay.Application.Services.RatingBranchs;
using Uplay.Persistence.Repository;

namespace Uplay.Application.Services.RatingBranch
{
    public class RatingBranchManager : BaseManager, IRatingBranchService
    {
        private readonly IRatingBranchRepository _ratingBranchRepository;

        public RatingBranchManager(
            IRatingBranchRepository ratingBranchRepository,
            IMapper mapper) : base(mapper)
        {
            _ratingBranchRepository = ratingBranchRepository;
        }

        public async Task<RatingBranchGetResponse> Get(int branchId)
        {
            RatingBranchGetResponse response = new();

            var ratingBranchs = _ratingBranchRepository.GetQuery().Where(x => x.BranchId == branchId).ToList()
                          ?? throw new NotFoundException("Rating Branch not found");

            int averageStar = 0;

            foreach (var ratingBranch in ratingBranchs)
                averageStar += ratingBranch.Rating;

            var mapping = new RatingBranchDto
            {
                TotalStar = ratingBranchs.Count(),
                AverageStar = averageStar / ratingBranchs.Count(),
            };

            response.RatingBranchDto = mapping;

            return response;
        }
    }
}
