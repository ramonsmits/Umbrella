using System;
using System.Collections.Generic;

namespace nVentive.Umbrella.Extensions
{
    public static class FuncExtensions
    {
        public static Func<T, bool> Not<T>(this Func<T, bool> func)
        {
            return item => !func(item);
        }

        public static Func<T> ToFunc<T>(this Func<Null, T> func)
        {
            return () => func(null);
        }

        public static Func<Null, T> ToFunc<T>(this Func<T> func)
        {
            return notUsed => func();
        }

        public static Action<TRequest> ToAction<TRequest, TResponse>(this Func<TRequest, TResponse> func)
        {
            // TODO: conver to method group?
            return item => func(item);
        }

        public static Action ToAction<TResponse>(this Func<Null, TResponse> func)
        {
            return () => func(null);
        }

        public static Action<TKey, TValue> ToAction<TKey, TValue>(this Action<KeyValuePair<TKey, TValue>> action)
        {
            return (i, item) => action(new KeyValuePair<TKey, TValue>(i, item));
        }

        public static Func<T, Null> ToFunc<T>(this Action<T> action)
        {
            return item =>
                       {
                           action(item);
                           return null;
                       };
        }

        public static Func<T, T> ToInterceptor<T>(this Action<T> action)
        {
            return item =>
                       {
                           action(item);
                           return item;
                       };
        }

        public static Func<Null, Null> ToFunc(this Action action)
        {
            return ToFunc<Null>(action);
        }

        public static Func<T, T> ToFunc<T>(this Action action)
        {
            return item =>
                       {
                           action();
                           return item;
                       };
        }

        public static Func<U> ToFunc<T, U>(this Func<T> func)
        {
            return () => (U) (object) func();
        }
    }
}