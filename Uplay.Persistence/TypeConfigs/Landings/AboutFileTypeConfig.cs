using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uplay.Domain.Entities.Models.Landing;

namespace Uplay.Persistence.TypeConfigs.Landings
{
    public class AboutFileTypeConfig : IEntityTypeConfiguration<AboutFile>
    {
        public void Configure(EntityTypeBuilder<AboutFile> builder)
        {
            builder.ToTable("AboutFiles", "Landing");
            builder.HasKey(e => e.Id);
            builder.HasQueryFilter(e => !e.Deleted);
        }
    }
}
