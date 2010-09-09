using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nVentive.Umbrella.Collections
{
    /// <summary>
    /// Default implementation for IGroupingExtensions
    /// </summary>
    public class DefaultGroupingExtensions : IGroupingExtensions
    {
        /// <summary>
        /// See base.   
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="groupings"></param>
        /// <returns></returns>
        public virtual Dictionary<TKey, IEnumerable<TElement>> ToGroupedDictionary<TKey, TElement>(IEnumerable<IGrouping<TKey, TElement>> items)
        {
            return items.ToDictionary<IGrouping<TKey, TElement>, TKey, IEnumerable<TElement>>(
                item => item.Key,
                item => item);
        }
    }
}
