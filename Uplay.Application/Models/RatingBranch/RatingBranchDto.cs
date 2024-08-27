using AutoMapper;
using Uplay.Application.Mappings;
using Uplay.Application.Models.PublicReviews;
using Uplay.Domain.Entities.Models.Landing;

namespace Uplay.Application.Models.RatingBranchs
{
    public class RatingBranchDto :IMapFrom<Uplay.Domain.Entities.Models.Landings.RatingBranch>
    {
        public int TotalStar { get; set; }
        public double AverageStar { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Uplay.Domain.Entities.Models.Landings.RatingBranch, RatingBranchDto>();
        }
    }
}
