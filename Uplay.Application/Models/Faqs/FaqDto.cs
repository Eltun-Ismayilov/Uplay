using Uplay.Application.Mappings;
using Uplay.Domain.Entities.Models.Landing;

namespace Uplay.Application.Models.Faqs;

public class FaqDto: BaseDto, IMapFrom<Faq>
{
    public string Name { get; set; }
    public string Description { get; set; }
}