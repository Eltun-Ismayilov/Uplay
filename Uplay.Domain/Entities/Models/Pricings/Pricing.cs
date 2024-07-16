namespace Uplay.Domain.Entities.Models.Pricings
{
    public class Pricing : CommonEntity
    {
        public double Price { get; set; } 
        public double Monthly { get; set; } 
        public string Currency { get; set; } 
        public double MonthDiscount { get; set; } 
        public int PricingTypeId { get; set; }
        public PricingType PricingType { get; set; }
        public ICollection<PricingSection> PricingSections { get; set; }
    }
}
