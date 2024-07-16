using AutoMapper;
using DnsClient;
using Uplay.Application.Mappings;
using Uplay.Domain.Entities.Models.Pricings;

namespace Uplay.Application.Models.Pricings
{
    public class PricingDto : BaseDto, IMapFrom<Pricing>
    {
        public double PriceDiscount { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; } = string.Empty;
        public double Monthly { get; set; }
        public PricingTypeDto PricingType { get; set; } = null!;
        public ICollection<PricingSectionDto> PricingSections { get; set; } = null!;
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Pricing, PricingDto>()
               .ForMember(dest => dest.PriceDiscount, opt => opt.MapFrom(src => src.Monthly == 1
                ? src.Price - ((src.Price * src.MonthDiscount) / 100)
                : (src.Price - ((3 * src.Price * src.MonthDiscount) / 100)) * 3 + (9 * src.Price)
                ))
              .ForMember(dest => dest.PricingType, opt => opt.MapFrom(src => src.PricingType))
              .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price * src.Monthly))
              .ForMember(dest => dest.PricingSections, opt => opt.MapFrom(src => src.PricingSections));
        }
    }
}
