using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uplay.Domain.Entities.Models.Miscs;

namespace Uplay.Persistence.TypeConfigs.Miscs
{
    public class AppFileTypeConfig : IEntityTypeConfiguration<AppFile>
    {
        public void Configure(EntityTypeBuilder<AppFile> builder)
        {
            builder.ToTable("AppFiles", "Misc");
            builder.HasKey(e => e.Id);
            builder.HasQueryFilter(e => !e.Deleted);
        }
    }
}
