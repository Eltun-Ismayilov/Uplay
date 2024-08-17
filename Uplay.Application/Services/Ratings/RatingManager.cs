using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Uplay.Application.Models.Ratings;
using Uplay.Domain.Entities.Models.Landings;
using Uplay.Persistence.Repository;

namespace Uplay.Application.Services.Ratings
{
    public class RatingManager : BaseManager, IRatingService
    {
        private readonly IRatingRepository _ratingRepository;

        public RatingManager(
            IRatingRepository ratingRepository,
            IMapper mapper) : base(mapper)
        {
            _ratingRepository = ratingRepository;
        }

        public async Task<ActionResult<int>> Create(SaveRatingRequest command)
        {
            var mapping = Mapper.Map<RatingBranch>(command);

            var data = await _ratingRepository.InsertAsync(mapping);

            return data;
        }
    }
}
