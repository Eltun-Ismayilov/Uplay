using Microsoft.EntityFrameworkCore;
using Uplay.Domain.Entities;
using Uplay.Domain.Entities.Models;

namespace Uplay.Persistence.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public virtual DbSet<AppFile> Files { get; set; } = null!;


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries())
            {

                switch (entry.State)
                {
                    case EntityState.Added:

                        var add = entry.Entity;

                        if (add is ICreatedDateEntity trackAdd)
                            trackAdd.CreatedDate = DateTime.UtcNow.AddHours(4);

                        if (add is ISoftDeletedEntity deletedEntity)
                            deletedEntity.Deleted = false;

                        break;

                    case EntityState.Modified:

                        var update = entry.Entity;

                        if (update is IUpdatedDateEntity trackupdate)
                            trackupdate.UpdatedDate = DateTime.UtcNow.AddHours(4);

                        break;

                }

            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
