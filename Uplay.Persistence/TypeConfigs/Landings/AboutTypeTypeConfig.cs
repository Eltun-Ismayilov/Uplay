using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uplay.Domain.Entities.Models.Landing;

namespace Uplay.Persistence.TypeConfigs.Landings
{
    public class AboutTypeTypeConfig : IEntityTypeConfiguration<AboutType>
    {
        public void Configure(EntityTypeBuilder<AboutType> builder)
        {
            builder.ToTable("AboutTypes", "Landing");
            builder.HasKey(e => e.Id);
            builder.HasQueryFilter(e => !e.Deleted);
        }
    }
}
