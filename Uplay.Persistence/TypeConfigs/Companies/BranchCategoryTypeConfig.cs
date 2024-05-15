using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uplay.Domain.Entities.Models.Companies;

namespace Uplay.Persistence.TypeConfigs.Companies
{
    public class BranchCategoryTypeConfig : IEntityTypeConfiguration<BranchCategory>
    {
        public void Configure(EntityTypeBuilder<BranchCategory> builder)
        {
            builder.ToTable("BranchCategories", "Company");
            builder.HasKey(e => e.Id);
            builder.HasQueryFilter(e => !e.Deleted);
        }
    }
}
