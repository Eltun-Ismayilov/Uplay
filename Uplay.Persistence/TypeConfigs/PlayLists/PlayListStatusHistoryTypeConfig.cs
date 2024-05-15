using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Uplay.Domain.Entities.Models.Miscs;
using Uplay.Domain.Entities.Models.PlayLists;

namespace Uplay.Persistence.TypeConfigs.PlayLists
{
    public class PlayListStatusHistoryTypeConfig : IEntityTypeConfiguration<PlayListStatusHistory>
    {
        public void Configure(EntityTypeBuilder<PlayListStatusHistory> builder)
        {
            builder.ToTable("PlayListStatusHistories", "PlayList");
            builder.HasKey(e => e.Id);
            builder.HasQueryFilter(e => !e.Deleted);
        }
    }
}
