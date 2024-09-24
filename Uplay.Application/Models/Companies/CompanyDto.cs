using Uplay.Application.Mappings;
using Uplay.Domain.Entities.Models.Companies;

namespace Uplay.Application.Models.Companies;

public class CompanyDto: BaseDto, IMapFrom<Company>
{
    public string BrandName { get; set; }
    public string CompanyName { get; set; }
    public string? Tin { get; set; }
    public string City { get; set; }
    public string Location { get; set; }
}