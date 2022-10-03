using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MewaAppBackend.WebApi.Extensions
{
    public static class RepositoryExtentions
    {
        public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes) where T : class
        {
            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }
    }
}
