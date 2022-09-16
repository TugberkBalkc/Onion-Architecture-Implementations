using EksiSozluk.API.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Interfaces.Repositories.Common
{
    public interface IAsyncRepository<T>
        where T : BaseEntity
    {
        Task<int> AddAsync(T entity);
        Task<int> AddRangeAsync(IEnumerable<T> entities);

        Task<int> DeleteAsync(T entity);
        Task<int> DeleteAsync(Guid entityId);
        Task<bool> DeleteRangeAsync(IEnumerable<T> entities);

        Task<int> UpdateAsync(T entity);

     
        Task<List<T>> GetAll(bool noTracking = true);

        Task<List<T>> GetList(Expression<Func<T, bool>> predicate, bool noTracking = true, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes);

        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, bool noTracking = true, params Expression<Func<T, object>>[] includes);

        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, bool noTracking = true, params Expression<Func<T, object>>[] includes);

        Task<int> SaveChangesAsync();

    }
}
