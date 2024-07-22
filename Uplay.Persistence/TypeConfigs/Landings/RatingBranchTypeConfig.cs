using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uplay.Domain.Entities.Models.Landings;

namespace Uplay.Persistence.TypeConfigs.Landings
{
    public class RatingBranchTypeConfig : IEntityTypeConfiguration<RatingBranch>
    {
        public void Configure(EntityTypeBuilder<RatingBranch> builder)
        {
            builder.ToTable("RatingBranchs", "Landing");
            builder.HasKey(e => e.Id);
            builder.HasQueryFilter(e => !e.Deleted);
        }
    }
}
