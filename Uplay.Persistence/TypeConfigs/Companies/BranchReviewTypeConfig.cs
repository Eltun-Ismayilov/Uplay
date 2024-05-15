using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uplay.Domain.Entities.Models.Companies;

namespace Uplay.Persistence.TypeConfigs.Companies
{
    internal class BranchReviewTypeConfig : IEntityTypeConfiguration<BranchReview>
    {
        public void Configure(EntityTypeBuilder<BranchReview> builder)
        {
            builder.ToTable("BranchReviews", "Company");
            builder.HasKey(e => e.Id);
            builder.HasQueryFilter(e => !e.Deleted);
        }
    }
}
