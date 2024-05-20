using AutoMapper;
using Uplay.Application.Mappings;
using Uplay.Domain.Entities.Models.Pricings;

namespace Uplay.Application.Models.Pricings
{
    public class PricingDto : BaseDto, IMapFrom<Pricing>
    {
        public double Amount { get; set; }
        public double Monthly { get; set; }
        public double Yearly { get; set; }
        public string Currency { get; set; } = string.Empty;
        public double ZeroToTenDiscount { get; set; }
        public double TenToTwentyDiscount { get; set; }
        public double FirstMonthDiscount { get; set; }
        public double AnnualDiscount { get; set; }
        public PricingTypeDto PricingType { get; set; } = null!;
        public ICollection<PricingSectionDto> PricingSections { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Pricing, PricingDto>()
                .ForMember(dest => dest.PricingType, opt => opt.MapFrom(src => src.PricingType))
                .ForMember(dest => dest.PricingSections, opt => opt.MapFrom(src => src.PricingSections));

        }
    }
}
