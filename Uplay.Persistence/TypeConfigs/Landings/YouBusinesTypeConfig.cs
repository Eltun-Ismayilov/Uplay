using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Uplay.Domain.Entities.Models.Landing;

namespace Uplay.Persistence.TypeConfigs.Landings
{
    internal class YouBusinesTypeConfig : IEntityTypeConfiguration<YouBusines>
    {
        public void Configure(EntityTypeBuilder<YouBusines> builder)
        {
            builder.ToTable("YouBusineses", "Landing");
            builder.HasKey(e => e.Id);
            builder.HasQueryFilter(e => !e.Deleted);
        }
    }
}
