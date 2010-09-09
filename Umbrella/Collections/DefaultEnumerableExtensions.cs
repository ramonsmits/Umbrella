using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Collections
{
    /// <summary>
    /// Default implementation for IEnumerableExtensions
    /// </summary>
    public class DefaultEnumerableExtensions : IEnumerableExtensions
    {
        /// <summary>
        /// See base.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        public virtual IEnumerable<T> ForEach<T>(IEnumerable<T> items)
        {
        }

        /// <summary>
        /// See base.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="action"></param>
        public virtual IEnumerable<T> ForEach<T>(IEnumerable<T> items, Action<T> action)
        {
        }
        
        /// <summary>
        /// See base.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="action"></param>
        public virtual IEnumerable<T> ForEach<T>(IEnumerable<T> items, Action<KeyValuePair<int, T>> action)
        {
        }

        /// <summary>
        /// See base.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="action"></param>
        public virtual IEnumerable<T> ForEach<T>(IEnumerable<T> items, Action<int, T> action)
        {
        }

        /// <summary>
        /// See base.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual bool None<T>(IEnumerable<T> items, Func<T, bool> predicate)
        {
        }

        /// <summary>
        /// See base.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public virtual bool Empty<T>(IEnumerable<T> items)
        {
        }

        /// <summary>
        /// See base.
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public virtual object[] ToObjectArray(IEnumerable items)
        {
        }

        /// <summary>
        /// See base.
        /// </summary>
        /// <param name="xItems"></param>
        /// <param name="yItems"></param>
        /// <returns></returns>
        public virtual IEnumerable<Pair<object>> Pair(IEnumerable xItems, IEnumerable yItems)
        {
        }

        /// <summary>
        /// See base.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xItems"></param>
        /// <param name="yItems"></param>
        /// <returns></returns>
        public virtual IEnumerable<Pair<T>> Pair<T>(IEnumerable<T> xItems, IEnumerable<T> yItems)
        {
        }

        /// <summary>
        /// See base.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual int IndexOf<T>(IEnumerable<T> items, T item)
        {
        }

        /// <summary>
        /// See base.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="item"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public virtual int IndexOf<T>(IEnumerable<T> items, T item, IEqualityComparer<T> comparer)
        {
        }

        /// <summary>
        /// See base.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="item"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual int IndexOf<T>(IEnumerable<T> items, T item, Func<T, T, bool> predicate)
        {
        }
    }
}
