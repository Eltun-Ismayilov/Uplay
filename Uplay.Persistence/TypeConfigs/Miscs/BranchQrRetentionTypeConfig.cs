using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uplay.Domain.Entities.Models.Miscs;

namespace Uplay.Persistence.TypeConfigs.Miscs;

public class BranchQrRetentionTypeConfig: IEntityTypeConfiguration<BranchQrRetention>
{
    public void Configure(EntityTypeBuilder<BranchQrRetention> builder)
    {
        builder.ToTable("BranchQrRetentions", "Misc");
        builder.HasKey(e => e.Id);
        builder.HasQueryFilter(e => !e.Deleted);
    }
}