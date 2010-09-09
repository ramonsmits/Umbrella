using System;
using System.Collections.Generic;
using System.Linq;
using nVentive.Umbrella.Collections;

namespace nVentive.Umbrella.Extensions
{
    /// <summary>
    /// Provides Extensions Methods for ICollection.
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// Adds a new item with the default constructor
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public static T AddNew<T>(this ICollection<T> items)
            where T : new()
        {
            T item = new T();

            items.Add(item);

            return item;
        }

        /// <summary>
        /// Adds the items of the specified collection to the end of the ICollection.
        /// </summary>
        /// <typeparam name="T">The type of the items.</typeparam>
        /// <param name="collection">Collection in which to insert items.</param>
        /// <param name="items">The items to add.</param>
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items)
        {
            items.ForEach(collection.Add);
        }

        /// <summary>
        /// Removes items in a collection that are identified with a predicate.
        /// </summary>
        /// <typeparam name="T">the type of the items</typeparam>
        /// <param name="collection">Collection in which to remove items.</param>
        /// <param name="predicate">The predicate used to identify if a item is to be removed or not.</param>
        public static void Remove<T>(this ICollection<T> collection, Func<T, bool> predicate)
        {
            collection
                .Where(predicate)
                .ToList()
                .ForEach(item => collection.Remove(item));
        }

        public static ICollection<U> Adapt<T, U>(this ICollection<T> collection)
        {
            return Adapt(collection, Funcs<U, T>.Convert, Funcs<T, U>.Convert);
        }

        /// <summary>
        /// Adapts a collection of type T into a collection of type U
        /// </summary>
        /// <typeparam name="T">The type to adapt.</typeparam>
        /// <typeparam name="U">The target type.</typeparam>
        /// <param name="collection">The collection to adapt</param>
        /// <param name="from">The function used to adapt a U into a T.</param>
        /// <param name="to">The function used to adapt a T into a U.</param>
        /// <returns>A adapted collection of the target type.</returns>
        public static ICollection<U> Adapt<T, U>(this ICollection<T> collection, Func<U, T> from, Func<T, U> to)
        {
            return new CollectionAdapter<T, U>(collection, from, to);
        }

        /// <summary>
        /// Replaces the items in a collection with a new set of items.
        /// </summary>
        /// <typeparam name="T">The type of items.</typeparam>
        /// <param name="collection">The collection who's content will be replaced.</param>
        /// <param name="items">The replacing items.</param>
        public static void ReplaceWith<T>(this ICollection<T> collection, IEnumerable<T> items)
        {
            collection.Clear();
            AddRange(collection, items);
        }

        public static IDisposable Subscribe<T>(this ICollection<T> collection, T item)
        {
            collection.Add(item);

            return Actions.Create(() => collection.Remove(item)).ToDisposable();
        }

        public static void AddDistinct<T>(this ICollection<T> collection, T item)
        {
            AddDistinct(collection, item, Predicates<T>.Equal);
        }

        public static void AddDistinct<T>(this ICollection<T> collection, T item, IEqualityComparer<T> comparer)
        {
            AddDistinct(collection, item, comparer.Equals);
        }

        public static void AddDistinct<T>(this ICollection<T> collection, T item, Func<T, T, bool> predicate)
        {
            if (collection.None(collectionItem => predicate(collectionItem, item)))
            {
                collection.Add(item);
            }
        }

        public static void AddRangeDistinct<T>(this ICollection<T> collection, IEnumerable<T> items)
        {
            AddRangeDistinct(collection, items, Predicates<T>.Equal);
        }

        public static void AddRangeDistinct<T>(this ICollection<T> collection, IEnumerable<T> items, IEqualityComparer<T> comparer)
        {
            AddRangeDistinct(collection, items, comparer.Equals);
        }

        public static void AddRangeDistinct<T>(this ICollection<T> collection, IEnumerable<T> items, Func<T, T, bool> predicate)
        {
            items.ForEach(item => collection.AddDistinct(item, predicate));
        }
    }
}