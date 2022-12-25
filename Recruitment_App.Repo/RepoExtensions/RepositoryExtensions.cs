using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Recruitment_App.Repo.RepoExtensions
{
    public static class RepositoryExtensions
    {
        public static IQueryable<TEntity> Includes<TEntity>(this IQueryable<TEntity> query, params Expression<Func<TEntity, object>>[] includes) where TEntity : class
        {
            if (includes != null)
            {
                foreach (Expression<Func<TEntity, object>> navigationPropertyPath in includes)
                {
                    query = query.Include(navigationPropertyPath);
                }
            }

            return query;
        }

        public static IQueryable<TEntity> MultipleWheres<TEntity>(this IQueryable<TEntity> query, params Expression<Func<TEntity, bool>>[] predicates) where TEntity : class
        {
            if (predicates != null)
            {
                foreach (Expression<Func<TEntity, bool>> cond in predicates)
                {
                    query = query.Where(cond);
                }
            }

            return query;
        }
    }
}
