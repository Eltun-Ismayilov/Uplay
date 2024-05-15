using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Uplay.Domain.Entities.Models.Pricings;

namespace Uplay.Persistence.TypeConfigs.Pricings
{
    public class PricingTypeTypeConfig : IEntityTypeConfiguration<PricingType>
    {
        public void Configure(EntityTypeBuilder<PricingType> builder)
        {
            builder.ToTable("PricingTypes", "Pricing");
            builder.HasKey(e => e.Id);
            builder.HasQueryFilter(e => !e.Deleted);
        }
    }
}
