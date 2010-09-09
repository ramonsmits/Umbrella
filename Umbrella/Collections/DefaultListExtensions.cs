using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using nVentive.Umbrella.Composite;

namespace nVentive.Umbrella.Collections
{
    /// <summary>
    /// Default implementation for IListExtensions
    /// </summary>
    public class DefaultListExtensions : IListExtensions
    {
        /// <summary>
        /// See base.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public virtual IList<T> AsReadOnly<T>(IList<T> items)
        {
            return new ReadOnlyCollection<T>(items);
        }

        /// <summary>
        /// See base.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="items"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public virtual IList<U> Adapt<T, U>(IList<T> items, Func<U, T> from, Func<T, U> to)
        {
            return new ListAdapter<T, U>(items, from, to);
        }

        public virtual IList<U> Adapt<T, U>(IList<T> items)
        {
            return Adapt<T, U>(items, Funcs<U, T>.Convert, Funcs<T, U>.Convert);
        }
    }
}
