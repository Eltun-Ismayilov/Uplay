using AutoMapper;
using Uplay.Application.Mappings;
using Uplay.Domain.Entities.Models.Landing;
using Uplay.Domain.Entities.Models.Landings;

namespace Uplay.Application.Models.Core.Feedbacks;

public class SaveFeedbackTypeRequest: IMapFrom<FeedbackType>
{
    public string Name { get; set; }
    public string Desc { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<SaveFeedbackTypeRequest, FeedbackType>();
    }
}