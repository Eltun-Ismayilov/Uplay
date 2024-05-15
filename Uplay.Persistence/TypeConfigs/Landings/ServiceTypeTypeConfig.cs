using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uplay.Domain.Entities.Models.Landing;

namespace Uplay.Persistence.TypeConfigs.Landings
{
    public class ServiceTypeTypeConfig : IEntityTypeConfiguration<ServiceType>
    {
        public void Configure(EntityTypeBuilder<ServiceType> builder)
        {
            builder.ToTable("ServiceTypes", "Landing");
            builder.HasKey(e => e.Id);
            builder.HasQueryFilter(e => !e.Deleted);
        }
    }
}
