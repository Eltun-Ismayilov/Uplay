using Uplay.Application.Mappings;
using Uplay.Application.Models.Core.Branches;
using Uplay.Domain.Entities.Models.Landing;

namespace Uplay.Application.Models.Core.Reviews;

public class ReviewDto:BaseDto, IMapFrom<Review>
{
    public string Name { get; set; }
    public BranchDto Branch { get; set; }
}