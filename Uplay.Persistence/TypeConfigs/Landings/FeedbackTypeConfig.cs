using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Uplay.Domain.Entities.Models.Landing;
using Uplay.Domain.Entities.Models.Landings;

namespace Uplay.Persistence.TypeConfigs.Landings
{
    public class FeedbackConfig : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.ToTable("Feedbacks", "Landing");
            builder.HasKey(e => e.Id);
            builder.HasQueryFilter(e => !e.Deleted);
        }
    }
    public class FeedbackTypeConfig : IEntityTypeConfiguration<FeedbackType>
    {
        public void Configure(EntityTypeBuilder<FeedbackType> builder)
        {
            builder.ToTable("FeedbackTypes", "public");
            builder.HasKey(e => e.Id);
            builder.HasQueryFilter(e => !e.Deleted);
        }
    }
}
