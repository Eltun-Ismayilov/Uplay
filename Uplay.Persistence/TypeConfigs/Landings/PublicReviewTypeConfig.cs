using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uplay.Domain.Entities.Models.Landing;

namespace Uplay.Persistence.TypeConfigs.Landings
{
    internal class PublicReviewTypeConfig : IEntityTypeConfiguration<PublicReview>
    {
        public void Configure(EntityTypeBuilder<PublicReview> builder)
        {
            builder.ToTable("PublicReviews", "Landing");
            builder.HasKey(e => e.Id);
            builder.HasQueryFilter(e => !e.Deleted);
        }
    }
}
