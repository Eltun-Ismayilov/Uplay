using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uplay.Domain.Entities.Models.Pricings;

namespace Uplay.Persistence.TypeConfigs.Pricings
{
    public class PricingSectionTypeConfig : IEntityTypeConfiguration<PricingSection>
    {
        public void Configure(EntityTypeBuilder<PricingSection> builder)
        {
            builder.ToTable("PricingSections", "Pricing");
            builder.HasKey(e => e.Id);
            builder.HasQueryFilter(e => !e.Deleted);
        }
    }
}
