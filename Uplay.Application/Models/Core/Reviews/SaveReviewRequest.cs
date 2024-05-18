using AutoMapper;
using Uplay.Application.Mappings;
using Uplay.Domain.Entities.Models.Landing;

namespace Uplay.Application.Models.Core.Reviews;

public class SaveReviewRequest: IMapFrom<Review>
{
    public string Name { get; set; }
    public int BranchId { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<SaveReviewRequest, Review>();
    }
}