using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uplay.Domain.Entities.Models.Landing;

namespace Uplay.Persistence.TypeConfigs.Landings
{
    public class SocialLinkTypeConfig : IEntityTypeConfiguration<SocialLink>
    {
        public void Configure(EntityTypeBuilder<SocialLink> builder)
        {
            builder.ToTable("SocialLinks", "Landing");
            builder.HasKey(e => e.Id);
            builder.HasQueryFilter(e => !e.Deleted);
        }
    }
}
