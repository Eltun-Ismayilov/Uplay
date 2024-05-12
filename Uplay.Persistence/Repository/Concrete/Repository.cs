using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Uplay.Persistence.Data;
using Uplay.Domain.Entities;

namespace Uplay.Persistence.Repository.Concrete
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, ISoftDeletedEntity, IUpdatedDateEntity
    {

        public readonly AppDbContext DbContext;
        private DbSet<T> Table => DbContext.Set<T>();
        private DatabaseFacade Database => DbContext.Database;
        private IDbContextTransaction Transaction => Database.CurrentTransaction;
        public DbSet<T> GetTable() => DbContext.Set<T>();
        public Repository(AppDbContext dbContext)
            => DbContext = dbContext;
        public IQueryable<T> GetQuery() => GetTable().Where(x => !x.Deleted).AsQueryable();

        public async Task<int> SaveChangesAsync() => await DbContext.SaveChangesAsync();

        public virtual IQueryable<T> AsQueryable(bool includeActive = true) =>
            AddDeletedFilter(Table, !includeActive);

        public async Task BeginTransaction()
        {
            if (Transaction is null) await Database.BeginTransactionAsync();
        }

        public async Task Commit()
        {
            if (Transaction is not null) await Database.CommitTransactionAsync();
        }

        public async Task Rollback()
        {
            if (Transaction is not null) await Database.RollbackTransactionAsync();
        }

        public async Task ToTransaction(Func<Task> action)
        {
            try
            {
                await BeginTransaction();
                await action.Invoke();
                await Commit();
            }
            catch (Exception e)
            {
                await Rollback();
                Console.WriteLine(e);
                throw;
            }
        }


        private async Task<int> SaveChangesAsync(bool saveChanges = true, CancellationToken cancellationToken = default)
        {
            if (saveChanges)
            {
                return await DbContext.SaveChangesAsync(cancellationToken);
            }

            return await Task.FromResult(1);
        }



        public async Task DeleteAsync(T entity, bool saveChanges = false)
        {
            entity.Deleted = true;
            entity.DeleteDate = DateTime.UtcNow.AddHours(4);
            Table.Update(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(IList<T> entities, bool saveChanges = false)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));


            await SaveChangesAsync(saveChanges);
        }

        public async Task DeleteAsync(Expression<Func<T, bool>> predicate, bool saveChanges = false)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            var entityList = await Table.Where(predicate).ToListAsync();
            entityList.ForEach(entity => entity.Deleted = true);

            await SaveChangesAsync(saveChanges);
        }

        public IQueryable<T> GetAllQuery(Func<IQueryable<T>, IQueryable<T>> func = null,
            bool includeDeleted = true)
        {
            var query = AddDeletedFilter(Table.AsQueryable(), includeDeleted);
            query = func != null ? func(query) : query;

            return query;
        }


        protected virtual IQueryable<T> AddDeletedFilter(IQueryable<T> query, in bool includeDeleted)
        {
            if (includeDeleted)
                return query;

            query = query.Where(x => !x.Deleted);

            return query;
        }

        public async Task<IList<T>> GetAllAsync(Func<IQueryable<T>, IQueryable<T>> func = null,
            bool includeDeleted = true) =>
            await GetAllQuery(func, includeDeleted).ToListAsync();


        public Task<T> GetByIdAsync(int? id, bool includeDeleted = true)
        {
            if (!id.HasValue || id == 0)
                return null;

            async Task<T> getEntityAsync()
            {
                return await AddDeletedFilter(Table, includeDeleted)
                    .FirstOrDefaultAsync(entity => entity.Id == id.Value && entity.Deleted == false);
            }

            return getEntityAsync();
        }

        public async Task<IList<T>> GetByIdsAsync(IList<int> ids, bool includeDeleted = true)
        {
            if (!ids?.Any() ?? true)
                return new List<T>();

            async Task<IList<T>> getByIdsAsync()
            {
                var query = AddDeletedFilter(Table, includeDeleted);

                //get entries
                var entries = await query.Where(entry => ids.Contains(entry.Id)).ToListAsync();

                //sort by passed identifiers
                var sortedEntries = new List<T>();
                foreach (var id in ids)
                {
                    var sortedEntry = entries.FirstOrDefault(entry => entry.Id == id);
                    if (sortedEntry != null)
                        sortedEntries.Add(sortedEntry);
                }

                return sortedEntries;
            }

            return await getByIdsAsync();
        }

        public async Task<int> InsertAsync(T entity, bool saveChanges = false)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await Table.AddAsync(entity);
            await SaveChangesAsync(saveChanges);
            return entity.Id;
        }

        public async Task InsertRangeAsync(IList<T> entities, bool saveChanges = false)
        {
            if (!entities?.Any() ?? true)
                throw new ArgumentNullException(nameof(entities));

            await Table.AddRangeAsync(entities);
            await SaveChangesAsync(saveChanges);
        }

        public async Task UpdateAsync(T entity, bool saveChanges = false)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            switch (DbContext.Entry(entity).State)
            {
                case EntityState.Added:
                case EntityState.Deleted:
                    throw new InvalidOperationException("EntityState not valid for update");

                case EntityState.Detached:
                    Table.Update(entity);
                    break;

                case EntityState.Unchanged:
                case EntityState.Modified:
                    break;

                default:
                    throw new InvalidOperationException("EntityState has not value");
            }

            await SaveChangesAsync(saveChanges);
        }
        public async Task UpdateAsync(IList<T> entities, bool saveChanges = false)
        {
            if (entities is null)
                throw new ArgumentNullException(nameof(entities));

            if (!entities.Any())
                return;

            async Task UpdateAll()
            {
                foreach (var entity in entities)
                    await UpdateAsync(entity, saveChanges);
            }

            await (saveChanges ? ToTransaction(UpdateAll) : UpdateAll());
        }
    }
}
