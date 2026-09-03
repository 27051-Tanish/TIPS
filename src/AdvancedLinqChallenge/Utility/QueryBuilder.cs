using System.Linq.Expressions;
using AdvancedLinqChallenge.Models.Enum;

namespace AdvancedLinqChallenge.LinqExtensions
{
    /// <summary>
    /// Construct complex LINQ queries that should support filtering, sorting, and joining data.
    /// </summary>
    /// <typeparam name="T">Type parameter that contains the IEnumerable</typeparam>
    public class QueryBuilder<T>
        where T : class
    {
        private IEnumerable<T> _list;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryBuilder{T}"/> class.
        /// </summary>
        /// <param name="list">A list of elements</param>
        public QueryBuilder(IEnumerable<T> list)
        {
            this._list = list;
        }

        /// <summary>
        /// OVERLOAD 2: Filters the collection
        /// </summary>
        /// <param name="filter">The filter to be applied.</param>
        /// <returns>The current query for method chaining.</returns>
        public QueryBuilder<T> Filter(Func<T, bool> filter)
        {
            this._list = this._list.Where(filter);
            return this; // allows method chaining.
        }

        /// <summary>
        /// OVERLOAD 2: Dynamic Expression Tree filter
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        /// <param name="condition">The condition that needs to be applied.</param>
        /// <param name="value">The value that needs to be checked for the property.</param>
        /// <returns>A filtered query for method chaining.</returns>
        public QueryBuilder<T> Filter(string propertyName, FilterConditions condition, object value)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
            {
                throw new ArgumentException("Property name cannot be empty.");
            }

            ParameterExpression parameter = Expression.Parameter(typeof(T), "t");
            Expression property = Expression.Property(parameter, propertyName);
            Expression constant = Expression.Constant(value);
            Expression body;

            switch (condition)
            {
                case FilterConditions.Contains:
                    body = Expression.Call(property, typeof(string).GetMethod("Contains", new[] { typeof(string) }), constant);
                    break;
                case FilterConditions.StartsWith:
                    body = Expression.Call(property, typeof(string).GetMethod("StartsWith", new[] { typeof(string) }), constant);
                    break;
                case FilterConditions.EndsWith:
                    body = Expression.Call(property, typeof(string).GetMethod("EndsWith", new[] { typeof(string) }), constant);
                    break;
                case FilterConditions.GreaterThanEqualTo:
                    body = Expression.GreaterThanOrEqual(property, Expression.Constant(value, property.Type));
                    break;
                case FilterConditions.LesserThanEqualTo:
                    body = Expression.LessThanOrEqual(property, Expression.Constant(value, property.Type));
                    break;
                default:
                    throw new ArgumentException("Unexpected filter condition.");
            }

            var lambda = Expression.Lambda<Func<T, bool>>(body, parameter);
            this._list = this._list.Where(lambda.Compile());
            return this;
        }

        /// <summary>
        /// Sorts the product details.
        /// </summary>
        /// <typeparam name="TKey">Type parameter</typeparam>
        /// <param name="keySelector">The key for performing the sort operation.</param>
        /// <returns>A filtered query for method chaining.</returns>
        public QueryBuilder<T> Sort<TKey>(Func<T, TKey> keySelector)
        {
            this._list = this._list.OrderBy(keySelector);
            return this; // allows method chaining.
        }

        /// <summary>
        /// Correlates the elements of two sequences based on matching keys.
        /// </summary>
        /// <typeparam name="TInner">The type of the elements of the inner sequence.</typeparam>
        /// <typeparam name="TKey">The type of the keys returned by the key selector functions.</typeparam>
        /// <typeparam name="TResult">The type of the result elements.</typeparam>
        /// <param name="inner">The sequence to join to the current collection.</param>
        /// <param name="outerKeySelector">A function to extract the join key from each element of the outer sequence.</param>
        /// <param name="innerKeySelector">A function to extract the join key from each element of the inner sequence.</param>
        /// <param name="resultSelector">A function to create a result element from two matching elements.</param>
        /// <returns>The joined sequence.</returns>
        public IEnumerable<TResult> Join<TInner, TKey, TResult>(
            IEnumerable<TInner> inner,
            Func<T, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<T, TInner, TResult> resultSelector)
        {
            var result = this.Execute();

            return result.Join(
                inner,
                outerKeySelector,
                innerKeySelector,
                resultSelector);
        }

        /// <summary>
        /// Executes and materialize the collections.
        /// </summary>
        /// <returns>A materialized collection</returns>
        public List<T> Execute()
        {
            return this._list.ToList();
        }
    }
}
