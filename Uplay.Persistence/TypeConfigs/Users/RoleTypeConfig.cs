using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uplay.Domain.Entities.Models.Users;
using Uplay.Domain.Seeders;

namespace Uplay.Persistence.TypeConfigs.Users
{
    public class RoleTypeConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles", "User");
            builder.HasKey(e => e.Id);
            builder.HasQueryFilter(e => !e.Deleted);
            builder.HasData(EntitySeeders.SeedRoles());

        }
    }
}
