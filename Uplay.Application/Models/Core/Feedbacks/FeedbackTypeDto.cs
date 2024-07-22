using Uplay.Application.Mappings;
using Uplay.Domain.Entities.Models.Landings;

namespace Uplay.Application.Models.Core.Feedbacks;

public class FeedbackTypeDto : BaseDto, IMapFrom<FeedbackType>
{
    public string Name { get; set; }
}