using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WorkData.Code.Repositories.Predicates
{
    public interface IPredicateGroup<T> where T : class
    {
        List<IPredicate<T>> Predicates { get; set; }

       void AddPredicate(bool condition, Expression<Func<T, bool>> expression);
    }
}