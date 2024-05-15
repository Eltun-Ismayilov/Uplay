using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uplay.Domain.Entities.Models.Companies;

namespace Uplay.Persistence.TypeConfigs.Companies
{
    public class CompanyBranchTypeConfig : IEntityTypeConfiguration<CompanyBranch>
    {
        public void Configure(EntityTypeBuilder<CompanyBranch> builder)
        {
            builder.ToTable("CompanyBranchs", "Company");
            builder.HasKey(e => e.Id);
            builder.HasQueryFilter(e => !e.Deleted);
        }
    }
}
