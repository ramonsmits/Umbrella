using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nVentive.Umbrella.Collections
{
    /// <summary>
    /// Provides Extensions Methods for IEnumerable.
    /// </summary>
    public interface IEnumerableExtensions
    {
        IEnumerable<T> ForEach<T>(IEnumerable<T> items);
        IEnumerable<T> ForEach<T>(IEnumerable<T> items, Action<T> action);
        IEnumerable<T> ForEach<T>(IEnumerable<T> items, Action<KeyValuePair<int, T>> action);
        IEnumerable<T> ForEach<T>(IEnumerable<T> items, Action<int, T> action);

        bool None<T>(IEnumerable<T> items, Func<T, bool> predicate);
        bool Empty<T>(IEnumerable<T> items);

        object[] ToObjectArray(IEnumerable items);
        IEnumerable<Pair<object>> Pair(IEnumerable xItems, IEnumerable yItems);
        IEnumerable<Pair<T>> Pair<T>(IEnumerable<T> xItems, IEnumerable<T> yItems);

        int IndexOf<T>(IEnumerable<T> items, T item);
        int IndexOf<T>(IEnumerable<T> items, T item, IEqualityComparer<T> comparer);
        int IndexOf<T>(IEnumerable<T> items, T item, Func<T, T, bool> predicate);

        //TODO ContainsAll<T>(IEnumerable<T> items, IEnumerable<T> itemsToFind);, ContainsAll<T, U>  Select + SequenceEqual
        //TODO ContainsAny(...)
    }
}
