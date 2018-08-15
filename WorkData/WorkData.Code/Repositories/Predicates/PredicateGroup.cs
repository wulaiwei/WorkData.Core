using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;

namespace WorkData.Code.Repositories.Predicates
{
    /// <summary>
    /// PredicateGroup
    /// </summary>
    public class PredicateGroup<T> : IPredicateGroup<T> where T : class
    {
        /// <summary>
        /// PredicateGroup
        /// </summary>
        public PredicateGroup()
        {
            Predicates = new List<WorkDataPredicate<T>>();
        }

        /// <summary>
        /// Predicates
        /// </summary>
        public List<WorkDataPredicate<T>> Predicates { get; set; }

        /// <summary>
        /// AddPredicate
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="expression"></param>
        public void AddPredicate(bool condition, Expression<Func<T, bool>> expression)
        {
            var predicate = new WorkDataPredicate<T>
            {
                Condition = condition,
                Expression = expression
            };

            Predicates.Add(predicate);
        }
    }
}
