using System;
using System.Linq.Expressions;

namespace WorkData.Code.Repositories.Predicates
{
    public interface IPredicate<T> where T : class
    {
        /// <summary>
        /// Condition
        /// </summary>
        bool Condition { get; set; }

        /// <summary>
        /// Expression
        /// </summary>
        Expression<Func<T, bool>> Expression { get; set; }
    }
}