using AutoMapper;
using Uplay.Application.Mappings;
using Uplay.Domain.Entities.Models.Landing;

namespace Uplay.Application.Models.Core.Feedbacks;

public class SaveFeedbackRequest : IMapFrom<Feedback>
{
    public string Name { get; set; }
    public string Desc { get; set; }
    public int BranchId { get; set; }
    public int FeedbackTypeId { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<SaveFeedbackRequest, Feedback>();
    }
}