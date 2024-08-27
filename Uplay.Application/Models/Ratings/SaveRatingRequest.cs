using AutoMapper;
using Uplay.Application.Mappings;
using Uplay.Domain.Entities.Models.Landings;

namespace Uplay.Application.Models.Ratings
{
    public class SaveRatingRequest : IMapFrom<Uplay.Domain.Entities.Models.Landings.RatingBranch>
    {
        public int Rating { get; set; }
        public int BranchId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SaveRatingRequest, Uplay.Domain.Entities.Models.Landings.RatingBranch>();
        }
    }
}
