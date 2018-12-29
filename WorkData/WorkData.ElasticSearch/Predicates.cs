// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.ElasticSearch
// 文件名：Predicates.cs
// 创建标识：吴来伟 2018-05-02 14:39
// 创建描述：
//
// 修改标识：吴来伟2018-05-03 15:25
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WorkData.ElasticSearch.Entity;
using WorkData.Util.Common.Helpers;

#endregion

namespace WorkData.ElasticSearch
{
    /// <summary>
    ///     谓语
    /// </summary>
    public static class Predicates
    {
        /// <summary>
        /// FieldTerms
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <param name="searchKey"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static IFieldTerms FieldTerms<T>(Expression<Func<T, object>> expression, string searchKey, int size) where T : class
        {
            var propertySearchName = (PropertySearchNameAttribute)
                LoadAttributeHelper.LoadAttributeByType<T, PropertySearchNameAttribute>(expression);

            return new FieldTerms
            {
                SearchKey = searchKey,
                PropertyName = propertySearchName.Name,
                Size = size
            };
        }

        /// <summary>
        ///     工厂方法创建一个新的  IFieldPredicate 谓语: [FieldName] [Operator] [Value].
        /// </summary>
        /// <typeparam name="T">实例类型</typeparam>
        /// <param name="expression">返回左操作数的表达式  [FieldName].</param>
        /// <param name="op">比较运算符</param>
        /// <param name="value">谓语的值.</param>
        /// <returns>An instance of IFieldPredicate.</returns>
        public static IFieldPredicate Field<T>(Expression<Func<T, object>> expression, ExpressOperator op, object value) where T : class
        {
            var propertySearchName = (PropertySearchNameAttribute)
                LoadAttributeHelper.LoadAttributeByType<T, PropertySearchNameAttribute>(expression);

            return new FieldPredicate<T>
            {
                PropertyName = propertySearchName.Name,
                ExpressOperator = op,
                Value = value
            };
        }

        /// <summary>
        ///     工厂方法创建一个新的 IPredicateGroup 谓语.
        ///     谓词组与其他谓词可以连接在一起.
        /// </summary>
        /// <param name="op">分组操作时使用的连接谓词 (AND / OR).</param>
        /// <param name="predicate">一组谓词列表.</param>
        /// <returns>An instance of IPredicateGroup.</returns>
        public static IPredicateGroup Group(GroupOperator op, params IPredicate[] predicate)
        {
            return new PredicateGroup
            {
                Operator = op,
                Predicates = predicate
            };
        }

        /// <summary>
        ///     工厂方法创建一个新的 sort 控制结果将如何排序。.
        /// </summary>
        public static SortField Sort<T>(Expression<Func<T, object>> expression, SortOrder sortOrder)
        {
            var propertySearchName = (PropertySearchNameAttribute)
                LoadAttributeHelper.LoadAttributeByType<T, PropertySearchNameAttribute>(expression);

            return new SortField
            {
                Field = propertySearchName.Name,
                Order = sortOrder
            };
        }

        /// <summary>
        ///     工厂方法创建一个新的 sort 控制结果将如何排序。.
        /// </summary>
        public static SortField Sort<T>(string expression, SortOrder sortOrder)
        {
            return new SortField
            {
                Field = expression,
                Order = sortOrder
            };
        }
    }

    /// <summary>
    ///     谓词接口
    /// </summary>
    public interface IPredicate
    {
        QueryContainer GetQuery(QueryContainer query);
    }

    /// <summary>
    ///     基础谓词接口
    /// </summary>
    public interface IBasePredicate : IPredicate
    {
        /// <summary>
        ///     属性名称
        /// </summary>
        string PropertyName { get; set; }
    }

    public abstract class BasePredicate : IBasePredicate
    {
        public string PropertyName { get; set; }

        public abstract QueryContainer GetQuery(QueryContainer query);
    }

    /// <summary>
    ///     比较谓词
    /// </summary>
    public interface IComparePredicate : IBasePredicate
    {
        /// <summary>
        ///     操作符
        /// </summary>
        ExpressOperator ExpressOperator { get; set; }
    }

    public abstract class ComparePredicate : BasePredicate
    {
        public ExpressOperator ExpressOperator { get; set; }
    }

    /// <summary>
    ///     字段谓词
    /// </summary>
    public interface IFieldPredicate : IComparePredicate
    {
        /// <summary>
        ///     谓词的值
        /// </summary>
        object Value { get; set; }
    }

    public class FieldPredicate<T> : ComparePredicate, IFieldPredicate
        where T : class
    {
        public object Value { get; set; }

        public override QueryContainer GetQuery(QueryContainer query)
        {
            switch (ExpressOperator)
            {
                case ExpressOperator.Eq:
                    query = new TermQuery
                    {
                        Field = PropertyName,
                        Value = Value
                    };
                    break;

                case ExpressOperator.Gt:
                    query = new TermRangeQuery
                    {
                        Field = PropertyName,
                        GreaterThan = Value.ToString()
                    };
                    break;

                case ExpressOperator.Ge:
                    query = new TermRangeQuery
                    {
                        Field = PropertyName,
                        GreaterThanOrEqualTo = Value.ToString()
                    };
                    break;

                case ExpressOperator.Lt:
                    query = new TermRangeQuery
                    {
                        Field = PropertyName,
                        LessThan = Value.ToString()
                    };
                    break;

                case ExpressOperator.Le:
                    query = new TermRangeQuery
                    {
                        Field = PropertyName,
                        LessThanOrEqualTo = Value.ToString()
                    };
                    break;

                case ExpressOperator.Like:
                    query = new MatchPhraseQuery
                    {
                        Field = PropertyName,
                        Query = Value.ToString()
                    };
                    break;

                case ExpressOperator.In:
                    query = new TermsQuery
                    {
                        Field = PropertyName,
                        Terms = (List<object>)Value
                    };
                    break;

                default:
                    throw new ElasticsearchException("构建Elasticsearch查询谓词异常");
            }
            return query;
        }
    }

    public interface IFieldTerms
    {
        /// <summary>
        /// 搜索名称
        /// </summary>
        string SearchKey { get; set; }

        /// <summary>
        ///     属性名称
        /// </summary>
        string PropertyName { get; set; }

        /// <summary>
        /// 大小
        /// </summary>
        int Size { get; set; }
    }

    /// <summary>
    /// FieldTerms
    /// </summary>
    public class FieldTerms : IFieldTerms
    {
        public string SearchKey { get; set; } = Guid.NewGuid().ToString();
        public string PropertyName { get; set; }
        public int Size { get; set; }
    }

    /// <summary>
    ///     比较操作符
    /// </summary>
    public enum ExpressOperator
    {
        /// <summary>
        ///     精准匹配 term（主要用于精确匹配哪些值，比如数字，日期，布尔值或 not_analyzed 的字符串(未经分析的文本数据类型)： ）
        /// </summary>
        Eq,

        /// <summary>
        ///     大于
        /// </summary>
        Gt,

        /// <summary>
        ///     大于等于
        /// </summary>
        Ge,

        /// <summary>
        ///     小于
        /// </summary>
        Lt,

        /// <summary>
        ///     小于等于
        /// </summary>
        Le,

        /// <summary>
        ///     模糊查询 (You can use % in the value to do wilcard searching)
        /// </summary>
        Like,

        /// <summary>
        /// in 查询
        /// </summary>
        In
    }

    /// <summary>
    ///     分组查询谓词
    /// </summary>
    public interface IPredicateGroup : IPredicate
    {
        /// <summary>
        /// </summary>
        GroupOperator Operator { get; set; }

        IList<IPredicate> Predicates { get; set; }
    }

    /// <summary>
    ///     分组查询谓词
    /// </summary>
    public class PredicateGroup : IPredicateGroup
    {
        public GroupOperator Operator { get; set; }
        public IList<IPredicate> Predicates { get; set; }

        /// <summary>
        ///     GetQuery
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public QueryContainer GetQuery(QueryContainer query)
        {
            switch (Operator)
            {
                case GroupOperator.And:
                    return Predicates.Aggregate(query, (q, p) => q && p.GetQuery(query));

                case GroupOperator.Or:
                    return Predicates.Aggregate(query, (q, p) => q || p.GetQuery(query));

                case GroupOperator.NotAnd:
                    return Predicates.Aggregate(query, (q, p) => q && !p.GetQuery(query));

                case GroupOperator.NotOr:
                    return Predicates.Aggregate(query, (q, p) => q || !p.GetQuery(query));

                default:
                    throw new ElasticsearchException("构建Elasticsearch查询谓词异常");
            }
        }
    }

    /// <summary>
    ///     PredicateGroup 加入谓词时使用的操作符
    /// </summary>
    public enum GroupOperator
    {
        And,
        Or,
        NotAnd,
        NotOr
    }
}