using AutoMapper;
using Uplay.Application.Mappings;
using Uplay.Domain.Entities.Models.Pricings;

namespace Uplay.Application.Models.Pricings
{
    public class SavePricingSectionRequest : IMapFrom<PricingSection>
    {
        public string Name { get; set; } = string.Empty;
        public void Mapping(Profile profile)
        {
            profile.CreateMap<SavePricingSectionRequest, PricingSection>();
        }
    }
}
