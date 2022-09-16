using EksiSozluk.API.Application.Interfaces.Repositories.Common;
using EksiSozluk.API.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EksiSozluk.API.Persistence.EntityFramework.Repositories.Common
{
    public class EfRepositoryBase<T> : IRepository<T>
        where T : BaseEntity
    {
        protected readonly DbContext _dbContext;

        protected DbSet<T> dbSet => _dbContext.Set<T>();

        public EfRepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public virtual int Add(T entity)
        {
            this.dbSet.Add(entity);
            return _dbContext.SaveChanges();
        }
        public int AddRange(IEnumerable<T> entities)
        {
            if (entities != null && !entities.Any())
                return 0;

            dbSet.AddRange(entities);
            return _dbContext.SaveChanges();
        }

        public virtual async Task<int> AddAsync(T entity)
        {
            await this.dbSet.AddAsync(entity);
            return await _dbContext.SaveChangesAsync();
        }
        public virtual async Task<int> AddRangeAsync(IEnumerable<T> entities)
        {
            if (entities != null && !entities.Any())
                return 0;

            await dbSet.AddRangeAsync(entities);
            return await _dbContext.SaveChangesAsync();
        }

        public virtual int Delete(T entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                this.dbSet.Attach(entity);
            }

            this.dbSet.Remove(entity);

            return _dbContext.SaveChanges();
        }
        public virtual int Delete(Guid entityId)
        {
            var entity = this.dbSet.Find(entityId);
            return Delete(entity);
        }
        public virtual bool DeleteRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
            return _dbContext.SaveChanges() > 0;
        }

        public virtual async Task<int> DeleteAsync(T entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                this.dbSet.Attach(entity);
            }

            this.dbSet.Remove(entity);

            return await _dbContext.SaveChangesAsync();
        }
        public virtual async Task<int> DeleteAsync(Guid entityId)
        {
            var entity = this.dbSet.Find(entityId);
            return await DeleteAsync(entity);
        }
        public virtual async Task<bool> DeleteRangeAsync(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public virtual int Update(T entity)
        {
            this.dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;

            return _dbContext.SaveChanges();
        }

        public virtual async Task<int> UpdateAsync(T entity)
        {
            this.dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;

            return await _dbContext.SaveChangesAsync();
        }


        public virtual IQueryable<T> AsQueryable() => dbSet.AsQueryable();

        public virtual async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, bool noTracking = true, params Expression<Func<T, object>>[] includes)
        {
            return await Get(predicate, noTracking, includes).FirstOrDefaultAsync();
        }

        public virtual IQueryable<T> Get(Expression<Func<T, bool>> predicate, bool noTracking = true, params Expression<Func<T, object>>[] includes)
        {
            var query = dbSet.AsQueryable();

            if (predicate != null)
                query = query.Where(predicate);

            query = ApplyIncludes(query, includes);

            if (noTracking)
                query = query.AsNoTracking();

            return query;
        }

        public T GetSingle(Expression<Func<T, bool>> predicate, bool noTracking = true, params Expression<Func<T, object>>[] includes)
        {
            var query = dbSet.AsQueryable();

            if (predicate != null)
                query = query.Where(predicate);

            query = ApplyIncludes(query, includes);

            if (noTracking)
                query = query.AsNoTracking();

            return query.SingleOrDefault();
        }

        public virtual async Task<List<T>> GetAll(bool noTracking = true)
        {
            if (noTracking)
                return await dbSet.AsNoTracking().ToListAsync();

            return await dbSet.ToListAsync();
        }

        public virtual async Task<List<T>> GetList(Expression<Func<T, bool>> predicate, bool noTracking = true, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = dbSet;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            foreach (Expression<Func<T, object>> include in includes)
            {
                query = query.Include(include);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (noTracking)
                query = query.AsNoTracking();

            return await query.ToListAsync();
        }

        public virtual async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, bool noTracking = true, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = dbSet;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            query = ApplyIncludes(query, includes);

            if (noTracking)
                query = query.AsNoTracking();

            return await query.SingleOrDefaultAsync();
        }

        
        
        private static IQueryable<T> ApplyIncludes(IQueryable<T> query, params Expression<Func<T, object>>[] includes)
        {
            if (includes != null)
            {
                foreach (var includeItem in includes)
                {
                    query = query.Include(includeItem);
                }
            }

            return query;
        }


        public async Task<int> SaveChangesAsync()
        {
            return await this._dbContext.SaveChangesAsync();
        }

        public void Attach(BaseEntity entity)
        {
           _dbContext.Attach(entity);
        }

        public int SaveChanges()
        {
            return this._dbContext.SaveChanges();
        }
    }
}
