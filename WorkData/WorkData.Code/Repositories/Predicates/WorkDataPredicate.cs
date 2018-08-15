using System;
using System.Linq.Expressions;

namespace WorkData.Code.Repositories.Predicates
{
    public class WorkDataPredicate<T> : IPredicate<T> where T : class
    {
        public bool Condition { get; set; }
        public Expression<Func<T, bool>> Expression { get; set; }
    }
}