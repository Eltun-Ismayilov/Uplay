using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Uplay.Domain.Entities;

namespace Uplay.Persistence.Repository
{
    public interface IRepository<T> where T : BaseEntity, ISoftDeletedEntity, IUpdatedDateEntity
    {
        IQueryable<T> AsQueryable(bool includeActive = false);

        Task BeginTransaction();

        Task Commit();

        Task Rollback();

        Task ToTransaction(Func<Task> action);

        Task<int> SaveChangesAsync();

        IQueryable<T> GetQuery();

        Task<T> GetByIdAsync(int? id, bool includeDeleted = true);

        DbSet<T> GetTable();

        Task<IList<T>> GetByIdsAsync(IList<int> ids, bool includeDeleted = true);

        IQueryable<T> GetAllQuery(Func<IQueryable<T>, IQueryable<T>> func = null,
            bool includeDeleted = true);

        Task<IList<T>> GetAllAsync(Func<IQueryable<T>, IQueryable<T>> func = null,
            bool includeDeleted = true);

        Task<int> InsertAsync(T entity, bool saveChanges = true);

        Task InsertRangeAsync(IList<T> entities, bool saveChanges = false);

        Task UpdateAsync(T entity, bool saveChanges = true);

        Task UpdateAsync(IList<T> entities, bool saveChanges = false);

        Task DeleteAsync(T entity, bool saveChanges = false);

        Task DeleteAsync(IList<T> entities, bool saveChanges = false);

        Task DeleteAsync(Expression<Func<T, bool>> predicate, bool saveChanges = false);
    }
}
