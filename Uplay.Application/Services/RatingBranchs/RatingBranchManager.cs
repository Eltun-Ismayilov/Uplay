using AutoMapper;
using System.Linq.Expressions;
using Uplay.Application.Exceptions;
using Uplay.Application.Extensions;
using Uplay.Application.Helpers;
using Uplay.Application.Models;
using Uplay.Application.Models.RatingBranch;
using Uplay.Application.Models.RatingBranchs;
using Uplay.Application.Services.RatingBranchs;
using Uplay.Domain.Entities.Models.Landing;
using Uplay.Domain.Entities.Models.Landings;
using Uplay.Persistence.Repository;
using RatingBranch = Uplay.Domain.Entities.Models.Landings.RatingBranch;

namespace Uplay.Application.Services.RatingBranchs
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

        public async Task<RatingBranchStatistics> GetCommonStatistics(FilterRatingBranchQuery filter)
        {
            var response = new RatingBranchStatistics();

            var predicate = CreateFilterQuery(PredicateBuilder.New<RatingBranch>(), filter);

            var data = _ratingBranchRepository.GetQuery().Where(predicate);

            int averageStar = 0;

            foreach (var ratingBranch in data)
                averageStar += ratingBranch.Rating;

            response.TotalStar = data.Count();
            response.AverageStar = averageStar;
            response.OneStar = data.Where(x => x.Rating == 1).Count();
            response.TwoStar = data.Where(x => x.Rating == 2).Count();
            response.ThreeStar = data.Where(x => x.Rating == 3).Count();
            response.FourStar = data.Where(x => x.Rating == 4).Count();
            response.FiveStar = data.Where(x => x.Rating == 5).Count();

            return response;
        }

        private static Expression<Func<RatingBranch, bool>>? CreateFilterQuery<RatingBranch>(
          Expression<Func<RatingBranch, bool>>? predicate,
          FilterRatingBranchQuery? filterQuery) where RatingBranch : IFilterable
        {
            if (filterQuery is null || predicate is null) return predicate;

            // Filter by date range
            if (filterQuery.StartDate.HasValue && filterQuery.EndDate.HasValue)
            {
                var startDate = filterQuery.StartDate.Value.Date;
                var endDate = filterQuery.EndDate.Value.Date;

                predicate = predicate.And(x =>
                    x.CreatedDate.Date >= startDate && x.CreatedDate.Date <= endDate);
            }
            else if (filterQuery.StartDate.HasValue)
            {
                var startDate = filterQuery.StartDate.Value.Date;
                predicate = predicate.And(x =>
                    x.CreatedDate.Date == startDate);
            }
            return predicate;
        }
    }
}
