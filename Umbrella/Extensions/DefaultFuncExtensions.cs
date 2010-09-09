using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nVentive.Umbrella.Extensions
{
    public class DefaultFuncExtensions : IFuncExtensions
    {
        #region IFuncExtensions Members

        public virtual Func<T, bool> Not<T>(Func<T, bool> func)
        {
        }

        public virtual Func<T> ToFunc<T>(Func<Null, T> func)
        {
        }

        public virtual Func<Null, T> ToFunc<T>(Func<T> func)
        {
        }

        public virtual Action<TRequest> ToAction<TRequest, TResponse>(Func<TRequest, TResponse> func)
        {
        }

        public virtual Action ToAction<TResponse>(Func<Null, TResponse> func)
        {
        }

        public virtual Action<TKey, TValue> ToAction<TKey, TValue>(Action<KeyValuePair<TKey, TValue>> action)
        {
        }

        public virtual Func<T, Null> ToFunc<T>(Action<T> action)
        {
        }

        public virtual Func<T, T> ToInterceptor<T>(Action<T> action)
        {
        }

        public virtual Func<Null, Null> ToFunc(Action action)
        {
        }

        public virtual Func<T, T> ToFunc<T>(Action action)
        {
        }

        public virtual Func<U> ToFunc<T, U>(Func<T> func)
        {
        }

        #endregion
    }
}
