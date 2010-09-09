using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Equality
{
    public class DefaultEqualityExtensions : IEqualityExtensions
    {
        #region IEqualityExtensions Members

        public virtual EqualityExtensionPoint<T> Equality<T>(T instance)
        {
            return new EqualityExtensionPoint<T>(instance);
        }

        public virtual int GetHashCode<T>(EqualityExtensionPoint<T> extensionPoint, IEnumerable<object> items)
        {
            int hashCode = 0;

            foreach (object item in items)
            {
                if (item != null)
                {
                    hashCode ^= item.GetHashCode();
                }
            }

            return hashCode;
        }

        public virtual int GetHashCode<T>(EqualityExtensionPoint<T> extensionPoint, Func<T, IEnumerable<object>> items)
        {
            return GetHashCode<T>(extensionPoint, items(extensionPoint.ExtendedValue));
        }

        public virtual bool Equal<T>(EqualityExtensionPoint<T> x, T y)
        {
            if (Object.Equals(x.ExtendedValue, y))
            {
                return true;
            }

            IEnumerable xItems = x.ExtendedValue as IEnumerable;

            if (xItems != null)
            {
                IEnumerable yItems = y as IEnumerable;

                if (yItems != null)
                {
                    return Equals(xItems, yItems, Predicates<object>.Equal);
                }
            }

            return false;
        }

        public virtual bool Equal<T>(EqualityExtensionPoint<T> x, object y, Func<T, IEnumerable<object>> content)
        {
            if (y is T)
            {
                return Equal(x, (T)y, content);
            }
            else
            {
                return false;
            }
        }

        public virtual bool Equal<T>(EqualityExtensionPoint<T> x, T y, Func<T, IEnumerable<object>> content)
        {
            return Equal<T>(x, y, content, Predicates<object>.Equal);
        }

        public virtual bool Equal<T>(EqualityExtensionPoint<T> x, T y, Func<T, IEnumerable<object>> content, IEqualityComparer comparer)
        {
            return Equal<T>(x, y, content, comparer.Equals);
        }

        public virtual bool Equal<T>(EqualityExtensionPoint<T> x, T y, Func<T, IEnumerable<object>> content, Func<object, object, bool> predicate)
        {
            IEnumerable<object> xItems = content(x.ExtendedValue);
            IEnumerable<object> yItems = content(y);

            return Equals(xItems, yItems, predicate);
        }

        public virtual bool Equal<T>(EqualityExtensionPoint<T> xItems, IEnumerable yItems) 
            where T : IEnumerable
        {
            return Equal<T>(xItems, yItems, Predicates<object>.Equal);
        }

        public virtual bool Equal<T>(EqualityExtensionPoint<T> xItems, IEnumerable yItems, IEqualityComparer comparer) 
            where T : IEnumerable
        {
            return Equal<T>(xItems, yItems, comparer.Equals);
        }

        public virtual bool Equal<T>(EqualityExtensionPoint<T> xItems, IEnumerable yItems, Func<object, object, bool> predicate) 
            where T : IEnumerable
        {
            return Equals(xItems.ExtendedValue, yItems, predicate);
        }

        public virtual bool Equal<T, TItem>(EqualityExtensionPoint<T> xItems, IEnumerable<TItem> yItems) 
            where T : IEnumerable<TItem>
        {
            return Equal<T, TItem>(xItems, yItems, Predicates<TItem>.Equal);
        }

        public virtual bool Equal<T, TItem>(EqualityExtensionPoint<T> xItems, IEnumerable<TItem> yItems, IEqualityComparer<TItem> comparer) 
            where T : IEnumerable<TItem>
        {
            return Equal<T, TItem>(xItems, yItems, comparer.Equals);
        }

        public virtual bool Equal<T, TItem>(EqualityExtensionPoint<T> xItems, IEnumerable<TItem> yItems, Func<TItem, TItem, bool> predicate) 
            where T : IEnumerable<TItem>
        {
            return xItems.ExtendedValue.SequenceEqual(yItems, predicate.Equality().ToComparer());
        }

        public virtual IEqualityComparer<T> ToComparer<T>(EqualityExtensionPoint<Func<T, T, bool>> extensionPoint)
        {
            return new FuncEqualityComparer<T>(extensionPoint.ExtendedValue);
        }

        #endregion

        protected virtual bool Equals(IEnumerable xItems, IEnumerable yItems, Func<object, object, bool> predicate)
        {
            IEnumerable<object> xNewItems = xItems.Cast<object>();
            IEnumerable<object> yNewItems = yItems.Cast<object>();

            return xNewItems.SequenceEqual(yNewItems, predicate.Equality().ToComparer());
        }
    }
}
