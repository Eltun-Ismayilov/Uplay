namespace Uplay.Domain.Entities.Models.Pricings
{
    public class PricingSection:CommonEntity
    {
        public string Name { get; set; }
        public int PricingId { get; set; }
        public Pricing Pricing { get; set; }
    }
}
