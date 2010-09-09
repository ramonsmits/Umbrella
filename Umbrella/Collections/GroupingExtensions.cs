using System.Collections.Generic;
using System.Linq;

namespace nVentive.Umbrella.Extensions
{
    /// <summary>
    /// Provides Extensions Methods for IGrouping.
    /// </summary>
    public static class GroupingExtensions
    {
        /// <summary>
        /// Adapts a IEnumarable of a IGrouping into a IDictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of the Key.</typeparam>
        /// <typeparam name="TElement">The type of the grouped element.</typeparam>
        /// <param name="items">The groupings to adapt.</param>
        /// <returns>A Dictionary containing the contents of the grouping.</returns>
        public static Dictionary<TKey, IEnumerable<TElement>>
            ToGroupedDictionary<TKey, TElement>(this IEnumerable<IGrouping<TKey, TElement>> items)
        {
            return items.ToDictionary<IGrouping<TKey, TElement>, TKey, IEnumerable<TElement>>(
                item => item.Key,
                item => item);
        }
    }
}