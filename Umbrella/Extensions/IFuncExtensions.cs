using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nVentive.Umbrella.Extensions
{
    public interface IFuncExtensions
    {
        Func<T, bool> Not<T>(Func<T, bool> func);
        Func<T> ToFunc<T>(Func<Null, T> func);
        Func<Null, T> ToFunc<T>(Func<T> func);
        Action<TRequest> ToAction<TRequest, TResponse>(Func<TRequest, TResponse> func);
        Action ToAction<TResponse>(Func<Null, TResponse> func);
        Action<TKey, TValue> ToAction<TKey, TValue>(Action<KeyValuePair<TKey, TValue>> action);

        Func<T, Null> ToFunc<T>(Action<T> action);
        Func<T, T> ToInterceptor<T>(Action<T> action);
        Func<Null, Null> ToFunc(Action action);
        Func<T, T> ToFunc<T>(Action action);
        Func<U> ToFunc<T, U>(Func<T> func);
    }
}
