using System;
using System.Collections.Generic;
using System.Linq;

using nVentive.Umbrella.Messages;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Collections
{
    /// <summary>
    /// Default implementation for ICollectionExtensions
    /// </summary>
    public class DefaultCollectionExtensions : ICollectionExtensions
    {
        #region ICollectionExtensions Members

        /// <summary>
        /// See base.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="items"></param>
        public virtual void AddRange<T>(ICollection<T> collection, IEnumerable<T> items)
        {
        }

        /// <summary>
        /// See base.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="predicate"></param>
        public virtual void Remove<T>(ICollection<T> collection, Func<T, bool> predicate)
        {
        }

        public virtual ICollection<U> Adapt<T, U>(ICollection<T> collection)
        {
        }

        /// <summary>
        /// See base.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="collection"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public virtual ICollection<U> Adapt<T, U>(ICollection<T> collection, Func<U, T> from, Func<T, U> to)
        {
        }

        /// <summary>
        /// See base.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="items"></param>
        public virtual void ReplaceWith<T>(ICollection<T> collection, IEnumerable<T> items)
        {
        }

        public virtual IDisposable Subscribe<T>(ICollection<T> collection, T item)
        {
        }

        public virtual void AddDistinct<T>(ICollection<T> collection, T item)
        {
        }

        public virtual void AddDistinct<T>(ICollection<T> collection, T item, IEqualityComparer<T> comparer)
        {
        }

        public virtual void AddDistinct<T>(ICollection<T> collection, T item, Func<T, T, bool> predicate)
        {
        }

        #endregion
    }
}
