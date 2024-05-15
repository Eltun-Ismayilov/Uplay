using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uplay.Domain.Entities.Models.Companies;

namespace Uplay.Persistence.TypeConfigs.Companies
{
    public class BranchFeedbackTypeConfig : IEntityTypeConfiguration<BranchFeedback>
    {
        public void Configure(EntityTypeBuilder<BranchFeedback> builder)
        {
            builder.ToTable("BranchFeedbacks", "Company");
            builder.HasKey(e => e.Id);
            builder.HasQueryFilter(e => !e.Deleted);
        }
    }
}
