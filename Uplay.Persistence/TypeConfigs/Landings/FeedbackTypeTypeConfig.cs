using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uplay.Domain.Entities.Models.Landings;

namespace Uplay.Persistence.TypeConfigs.Landings
{
    public class FeedbackTypeTypeConfig : IEntityTypeConfiguration<FeedbackType>
    {
        public void Configure(EntityTypeBuilder<FeedbackType> builder)
        {
            builder.ToTable("FeedbackTypes", "Landing");
            builder.HasKey(e => e.Id);
            builder.HasQueryFilter(e => !e.Deleted);
        }
    }
}
