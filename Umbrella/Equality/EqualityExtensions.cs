using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using nVentive.Umbrella.Equality;

namespace nVentive.Umbrella.Extensions
{
    public static class EqualityExtensions
    {
        public static EqualityExtensionPoint<T> Equality<T>(this T instance)
        {
            return new EqualityExtensionPoint<T>(instance);
        }

        public static int GetHashCode<T>(this EqualityExtensionPoint<T> extensionPoint, IEnumerable<object> items)
        {
            var hashCode = typeof(T).GetHashCode();

            foreach (var item in items)
            {
                if (item != null)
                {
                    hashCode = (int)(0xa5555529 * hashCode) + item.GetHashCode();
                }
            }

            return hashCode;
        }

        public static int GetHashCode<T>(this EqualityExtensionPoint<T> extensionPoint,
                                         Func<T, IEnumerable<object>> items)
        {
            return GetHashCode(extensionPoint, items(extensionPoint.ExtendedValue));
        }

        public static bool Equal<T>(this EqualityExtensionPoint<T> x, T y)
        {
            if (Equals(x.ExtendedValue, y))
            {
                return true;
            }

            var xItems = x.ExtendedValue as IEnumerable;

            if (xItems != null)
            {
                var yItems = y as IEnumerable;

                if (yItems != null)
                {
                    return Equals(xItems, yItems, Predicates<object>.Equal);
                }
            }

            return false;
        }

        public static bool Equal<T>(this EqualityExtensionPoint<T> x, object y, Func<T, IEnumerable<object>> content)
        {
            if (y is T)
            {
                return Equal(x, (T) y, content);
            }
            return false;
        }

        public static bool Equal<T>(this EqualityExtensionPoint<T> x, T y, Func<T, IEnumerable<object>> content)
        {
            return Equal(x, y, content, Predicates<object>.Equal);
        }

        public static bool Equal<T>(this EqualityExtensionPoint<T> x, T y, Func<T, IEnumerable<object>> content,
                                    IEqualityComparer comparer)
        {
            return Equal(x, y, content, comparer.Equals);
        }

        public static bool Equal<T>(this EqualityExtensionPoint<T> x, T y, Func<T, IEnumerable<object>> content,
                                    Func<object, object, bool> predicate)
        {
            var xItems = content(x.ExtendedValue);
            var yItems = content(y);

            return Equals(xItems, yItems, predicate);
        }

        //TODO Useful?
        public static bool Equal<T>(this EqualityExtensionPoint<T> xItems, IEnumerable yItems)
            where T : IEnumerable
        {
            return Equal(xItems, yItems, Predicates<object>.Equal);
        }

        public static bool Equal<T>(this EqualityExtensionPoint<T> xItems, IEnumerable yItems,
                                    IEqualityComparer comparer)
            where T : IEnumerable
        {
            return Equal(xItems, yItems, comparer.Equals);
        }

        public static bool Equal<T>(this EqualityExtensionPoint<T> xItems, IEnumerable yItems,
                                    Func<object, object, bool> predicate)
            where T : IEnumerable
        {
            return Equals(xItems.ExtendedValue, yItems, predicate);
        }

        public static bool Equal<T, TItem>(this EqualityExtensionPoint<T> xItems, IEnumerable<TItem> yItems)
            where T : IEnumerable<TItem>
        {
            return Equal(xItems, yItems, Predicates<TItem>.Equal);
        }

        public static bool Equal<T, TItem>(this EqualityExtensionPoint<T> xItems, IEnumerable<TItem> yItems,
                                           IEqualityComparer<TItem> comparer)
            where T : IEnumerable<TItem>
        {
            return Equal(xItems, yItems, comparer.Equals);
        }

        public static bool Equal<T, TItem>(this EqualityExtensionPoint<T> xItems, IEnumerable<TItem> yItems,
                                           Func<TItem, TItem, bool> predicate)
            where T : IEnumerable<TItem>
        {
            return xItems.ExtendedValue.SequenceEqual(yItems, predicate.Equality().ToComparer());
        }

        public static IEqualityComparer<T> ToComparer<T>(this EqualityExtensionPoint<Func<T, T, bool>> extensionPoint)
        {
            return new FuncEqualityComparer<T>(extensionPoint.ExtendedValue);
        }

        public static bool Equals(IEnumerable xItems, IEnumerable yItems, Func<object, object, bool> predicate)
        {
            var xNewItems = xItems.Cast<object>();
            var yNewItems = yItems.Cast<object>();

            return xNewItems.SequenceEqual(yNewItems, predicate.Equality().ToComparer());
        }
    }
}
