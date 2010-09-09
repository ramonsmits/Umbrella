using System;
using System.Collections.Generic;

namespace nVentive.Umbrella.Equality
{
    public class FuncEqualityComparer<T> : IEqualityComparer<T>
    {
        private readonly Func<T, T, bool> predicate;

        public FuncEqualityComparer(Func<T, T, bool> predicate)
        {
            this.predicate = predicate;
        }

        #region IEqualityComparer<T> Members

        public bool Equals(T x, T y)
        {
            return predicate(x, y);
        }

        public int GetHashCode(T obj)
        {
            return obj.GetHashCode();
        }

        #endregion
    }
}