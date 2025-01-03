using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uplay.Domain.Entities.Models.Users;
using Uplay.Domain.Seeders;

namespace Uplay.Persistence.TypeConfigs.Users
{
    public class ClaimTypeConfig : IEntityTypeConfiguration<Claim>
    {
        public void Configure(EntityTypeBuilder<Claim> builder)
        {
            builder.ToTable("Claims", "User");
            builder.HasKey(e => e.Id);
            builder.HasQueryFilter(e => !e.Deleted);
            builder.HasData(EntitySeeders.SeedClaims());

        }
    }
}
