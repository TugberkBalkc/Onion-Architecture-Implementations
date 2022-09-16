using EksiSozluk.API.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Application.Interfaces.Repositories.Common
{
    public interface ISyncRepository<T>
        where T : BaseEntity
    {
        int Add(T entity);
        int AddRange(IEnumerable<T> entities);

        int Delete(T entity);
        int Delete(Guid entityId);
        bool DeleteRange(IEnumerable<T> entities);

        int Update(T entity);



        IQueryable<T> AsQueryable();
        IQueryable<T> Get(Expression<Func<T, bool>> predicate, bool noTracking = true, params Expression<Func<T, object>>[] includes);
        T GetSingle(Expression<Func<T, bool>> predicate, bool noTracking = true, params Expression<Func<T, object>>[] includes);
        void Attach(BaseEntity entity);

        int SaveChanges();

    }
}
