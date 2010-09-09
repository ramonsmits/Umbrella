using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace nVentive.Umbrella.Equality
{
    public interface IEqualityExtensions
    {
        EqualityExtensionPoint<T> Equality<T>(T instance);

        int GetHashCode<T>(EqualityExtensionPoint<T> extensionPoint, IEnumerable<object> items);
        int GetHashCode<T>(EqualityExtensionPoint<T> extensionPoint, Func<T,IEnumerable<object>> items);

        bool Equal<T>(EqualityExtensionPoint<T> x, T y);
        bool Equal<T>(EqualityExtensionPoint<T> x, object y, Func<T, IEnumerable<object>> content);
        bool Equal<T>(EqualityExtensionPoint<T> x, T y, Func<T, IEnumerable<object>> content);
        bool Equal<T>(EqualityExtensionPoint<T> x, T y, Func<T, IEnumerable<object>> content, IEqualityComparer comparer);
        bool Equal<T>(EqualityExtensionPoint<T> x, T y, Func<T, IEnumerable<object>> content, Func<object, object, bool> predicate);

        bool Equal<T>(EqualityExtensionPoint<T> xItems, IEnumerable yItems)
            where T : IEnumerable;

        bool Equal<T>(EqualityExtensionPoint<T> xItems, IEnumerable yItems, IEqualityComparer comparer)
            where T : IEnumerable;

        bool Equal<T>(EqualityExtensionPoint<T> xItems, IEnumerable yItems, Func<object, object, bool> predicate)
            where T : IEnumerable;

        bool Equal<T, TItem>(EqualityExtensionPoint<T> xItems, IEnumerable<TItem> yItems)
            where T : IEnumerable<TItem>;

        bool Equal<T, TItem>(EqualityExtensionPoint<T> xItems, IEnumerable<TItem> yItems, IEqualityComparer<TItem> comparer)
            where T : IEnumerable<TItem>;

        bool Equal<T, TItem>(EqualityExtensionPoint<T> xItems, IEnumerable<TItem> yItems, Func<TItem, TItem, bool> predicate)
            where T : IEnumerable<TItem>;

        IEqualityComparer<T> ToComparer<T>(EqualityExtensionPoint<Func<T, T, bool>> extensionPoint);
    }
}
