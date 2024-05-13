namespace Uplay.Domain.Entities.Models
{
    public class Pricing:CommonEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string SubDescription { get; set; }
        public double Amount { get; set; }
        public int PricingTypeId { get; set; }
        public PricingType PricingType { get; set; }
    }
}
