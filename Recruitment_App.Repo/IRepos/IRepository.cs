using System.Linq.Expressions;

namespace Recruitment_App.Repo.IRepos
{
    public interface IRepository<T, TT>
    {
        Task<T> AddAsync(T entity);
        Task AddBulkAsync(List<T> entities);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteBulkAsync(Expression<Func<T, bool>> predicate);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(TT id);
        Task<T> GetByIdAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes);
        Task<T> GetByIdAsync(List<Expression<Func<T, bool>>> filters = null, params Expression<Func<T, object>>[] includes);
        Task<IReadOnlyList<T>> GetAsync(List<Expression<Func<T, bool>>> predicates = null,
                                 Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                 List<Expression<Func<T, object>>> includes = null,
                                 bool disableTracking = true);
    }
}
