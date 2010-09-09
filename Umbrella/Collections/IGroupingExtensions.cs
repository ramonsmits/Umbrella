using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nVentive.Umbrella.Collections
{
    /// <summary>
    /// Provides Extensions Methods for IGrouping.
    /// </summary>
    public interface IGroupingExtensions
    {
        /// <summary>
        /// Adapts a IEnumarable of a IGrouping into a IDictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of the Key.</typeparam>
        /// <typeparam name="TElement">The type of the grouped element.</typeparam>
        /// <param name="items">The groupings to adapt.</param>
        /// <returns>A Dictionary containing the contents of the grouping.</returns>
        Dictionary<TKey, IEnumerable<TElement>>
            ToGroupedDictionary<TKey, TElement>(IEnumerable<IGrouping<TKey, TElement>> items);
    }
}
