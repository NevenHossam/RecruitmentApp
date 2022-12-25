using Microsoft.EntityFrameworkCore;
using Recruitment_App.Repo.Context;
using Recruitment_App.Repo.IRepos;
using Recruitment_App.Repo.RepoExtensions;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Recruitment_App.Repo.Repos
{
    public class RepositoryBase<T, TT> : IRepository<T, TT> where T : class
    {
        private readonly RecruitmentContext _dbContext;
        public RepositoryBase(RecruitmentContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes)
        {
            return await _dbContext.Set<T>().AsNoTracking().Where(filter).Includes(includes).FirstOrDefaultAsync();
        }

        public async Task<T> GetByIdAsync(List<Expression<Func<T, bool>>> filters, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

            if (filters != null) query = filters.Aggregate(query, (current, cond) => current.MultipleWheres(cond));

            return await query.FirstOrDefaultAsync();
        }

        public async Task<T> GetByIdAsync(TT id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetAsync(List<Expression<Func<T, bool>>> predicates = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<Expression<Func<T, object>>> includes = null, bool disableTracking = true)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            if (disableTracking) query = query.AsNoTracking();

            if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

            if (predicates != null) query = predicates.Aggregate(query, (current, cond) => current.MultipleWheres(cond));

            if (orderBy != null) return await orderBy(query).ToListAsync();

            return await query.ToListAsync();
        }

        public async Task DeleteBulkAsync(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            query = query.Where(predicate);
            _dbContext.Set<T>().RemoveRange(query);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddBulkAsync(List<T> entities)
        {
            await _dbContext.Set<T>().AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();
        }
    }
}
