using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nVentive.Umbrella.Collections
{
    /// <summary>
    /// Provides Extensions Methods for ICollection.
    /// </summary>
    public interface ICollectionExtensions
    {
        /// <summary>
        /// Adds the items of the specified collection to the end of the ICollection.
        /// </summary>
        /// <typeparam name="T">The type of the items.</typeparam>
        /// <param name="collection">Collection in which to insert items.</param>
        /// <param name="items">The items to add.</param>
        void AddRange<T>(ICollection<T> collection, IEnumerable<T> items);

        /// <summary>
        /// Removes items in a collection that are identified with a predicate.
        /// </summary>
        /// <typeparam name="T">the type of the items</typeparam>
        /// <param name="collection">Collection in which to remove items.</param>
        /// <param name="predicate">The predicate used to identify if a item is to be removed or not.</param>
        void Remove<T>(ICollection<T> collection, Func<T, bool> predicate);

        ICollection<U> Adapt<T, U>(ICollection<T> collection);

        /// <summary>
        /// Adapts a collection of type T into a collection of type U
        /// </summary>
        /// <typeparam name="T">The type to adapt.</typeparam>
        /// <typeparam name="U">The target type.</typeparam>
        /// <param name="collection">The collection to adapt</param>
        /// <param name="from">The function used to adapt a U into a T.</param>
        /// <param name="to">The function used to adapt a T into a U.</param>
        /// <returns>A adapted collection of the target type.</returns>
        ICollection<U> Adapt<T, U>(ICollection<T> collection, Func<U, T> from, Func<T, U> to);

        /// <summary>
        /// Replaces the items in a collection with a new set of items.
        /// </summary>
        /// <typeparam name="T">The type of items.</typeparam>
        /// <param name="collection">The collection who's content will be replaced.</param>
        /// <param name="items">The replacing items.</param>
        void ReplaceWith<T>(ICollection<T> collection, IEnumerable<T> items);

        IDisposable Subscribe<T>(ICollection<T> collection, T item);

        void AddDistinct<T>(ICollection<T> collection, T item);
        void AddDistinct<T>(ICollection<T> collection, T item, IEqualityComparer<T> comparer);
        void AddDistinct<T>(ICollection<T> collection, T item, Func<T, T, bool> predicate);
    }
}
