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
        /// Filters the collection
        /// </summary>
        /// <param name="filter">The filter to be applied.</param>
        /// <returns>The current query for method chaining.</returns>
        public QueryBuilder<T> Filter(Func<T, bool> filter)
        {
            this._list = this._list.Where(filter);
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
            return this;
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
