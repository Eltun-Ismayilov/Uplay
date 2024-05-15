using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uplay.Domain.Entities.Models.Landing;

namespace Uplay.Persistence.TypeConfigs.Landings
{
    public class PartnerTypeConfig : IEntityTypeConfiguration<Partner>
    {
        public void Configure(EntityTypeBuilder<Partner> builder)
        {
            builder.ToTable("Partners", "Landing");
            builder.HasKey(e => e.Id);
            builder.HasQueryFilter(e => !e.Deleted);
        }
    }
}
