using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using nVentive.Umbrella.Composite;

namespace nVentive.Umbrella.Collections
{
    /// <summary>
    /// Provides Extensions Methods for IList.
    /// </summary>
    public interface IListExtensions
    {
        /// <summary>
        /// Returns a readonly instance of the specified list.
        /// </summary>
        /// <typeparam name="T">The type of the IList</typeparam>
        /// <param name="items">The list</param>
        /// <returns>A readonly instance of the specified list.</returns>
        IList<T> AsReadOnly<T>(IList<T> items);

        /// <summary>
        /// Adapts a list of type T into a list of type U
        /// </summary>
        /// <typeparam name="T">The type to adapt.</typeparam>
        /// <typeparam name="U">The target type.</typeparam>
        /// <param name="items">The list to adapt</param>
        /// <param name="from">The function used to adapt a U into a T.</param>
        /// <param name="to">The function used to adapt a T into a U.</param>
        /// <returns>A adapted list of the target type.</returns>
        IList<U> Adapt<T, U>(IList<T> items, Func<U, T> from, Func<T, U> to);

        IList<U> Adapt<T, U>(IList<T> items);
    }
}
