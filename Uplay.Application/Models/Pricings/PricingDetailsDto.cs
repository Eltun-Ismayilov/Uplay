using AutoMapper;
using Uplay.Application.Mappings;
using Uplay.Domain.Entities.Models.Pricings;

namespace Uplay.Application.Models.Pricings
{
    public class PricingDetailsDto : BaseDto, IMapFrom<Pricing>
    {
        public double PriceDiscount { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; } = string.Empty;
        public double Monthly { get; set; }
        public PricingTypeDto PricingType { get; set; } = null!;
        public ICollection<PricingSectionDto> PricingSections { get; set; } = null!;
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Pricing, PricingDetailsDto>()
                .ForMember(dest => dest.PriceDiscount, opt => opt.MapFrom(src => src.Price - (((src.Price * src.MonthDiscount * src.Monthly)) / 100)))
                .ForMember(dest => dest.PricingType, opt => opt.MapFrom(src => src.PricingType))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price * src.Monthly))
                .ForMember(dest => dest.PricingSections, opt => opt.MapFrom(src => src.PricingSections));
        }
    }
}
