using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uplay.Domain.Entities.Models.Companies;

namespace Uplay.Persistence.TypeConfigs.Companies
{
    public class BranchQrCodeTypeConfig : IEntityTypeConfiguration<BranchQrCode>
    {
        public void Configure(EntityTypeBuilder<BranchQrCode> builder)
        {
            builder.ToTable("BranchQrCodes", "Company");
            builder.HasKey(e => e.Id);
            builder.HasQueryFilter(e => !e.Deleted);
        }
    }
}
