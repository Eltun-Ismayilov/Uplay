using Uplay.Application.Mappings;
using Uplay.Domain.Entities.Models.Companies;

namespace Uplay.Application.Models.Core.Branches;

public class BranchDto: BaseDto, IMapFrom<Branch>
{
    public string Name { get; set; }
    public string City { get; set; }
    public string Location { get; set; }
}