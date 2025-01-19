using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uplay.Domain.Entities.Models.Users;
using Uplay.Domain.Seeders;

namespace Uplay.Persistence.TypeConfigs.Users
{
    public class RoleClaimTypeConfig : IEntityTypeConfiguration<RoleClaim>
    {
        public void Configure(EntityTypeBuilder<RoleClaim> builder)
        {
            builder.ToTable("RoleClaims", "User");
            builder.HasKey(e => e.Id);
            builder.HasQueryFilter(e => !e.Deleted);
            //builder.HasData(EntitySeeders.SeedRoleClaims());
        }
    }
}
