using AutoMapper;
using Uplay.Application.Mappings;
using Uplay.Domain.Entities.Models.Pricings;

namespace Uplay.Application.Models.Pricings
{
    public class SavePricingRequest : IMapFrom<Pricing>
    {
        public double Amount { get; set; }
        public double Monthly { get; set; }
        public double Yearly { get; set; }
        public string Currency { get; set; } = string.Empty;
        public double ZeroToTenDiscount { get; set; }
        public double TenToTwentyDiscount { get; set; }
        public double FirstMonthDiscount { get; set; }
        public double AnnualDiscount { get; set; }
        public int PricingTypeId { get; set; }
        public ICollection<SavePricingSectionRequest> SavePricingSectionRequests { get; set; } = null!;
        public void Mapping(Profile profile)
        {
            profile.CreateMap<SavePricingRequest, Pricing>()
             .ForMember(dest => dest.PricingSections, opt => opt.MapFrom(src => src.SavePricingSectionRequests));
        }
    }
}
