using Microsoft.EntityFrameworkCore;
using System.Linq;
using WorkData.Code.Repositories.Predicates;

namespace WorkData.EntityFramework.Extensions
{
    public static class QueryExtension
    {
        /// <summary>
        ///     WhereIf
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicateGroup"></param>
        /// <returns></returns>
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> source, IPredicateGroup<T> predicateGroup)
            where T : class
        {
            return predicateGroup.Predicates
                .Aggregate(source,
                    (current, predicate) =>
                        predicate.Condition ? current.Where(predicate.Expression) : current);
        }

        /// <summary>
        ///     WhereIf
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbSet"></param>
        /// <param name="predicateGroup"></param>
        /// <returns></returns>
        public static IQueryable<T> WhereIf<T>(this DbSet<T> dbSet, IPredicateGroup<T> predicateGroup)
            where T : class
        {
            return predicateGroup.Predicates
                .Aggregate(dbSet.AsQueryable(),
                    (current, predicate) =>
                        predicate.Condition ? current.Where(predicate.Expression) : current);
        }
    }
}