namespace Uplay.Domain.Entities.Models.Pricings
{
    public class Pricing : CommonEntity
    {
        public double Amount { get; set; }
        public double Monthly { get; set; }
        public double Yearly { get; set; }
        public string Currency { get; set; }
        public double ZeroToTenDiscount { get; set; }
        public double TenToTwentyDiscount { get; set; }
        public double FirstMonthDiscount { get; set; }
        public double AnnualDiscount { get; set; }
        public int PricingTypeId { get; set; }
        public PricingType PricingType { get; set; }
        public ICollection<PricingSection> PricingSections { get; set; }
    }
}
