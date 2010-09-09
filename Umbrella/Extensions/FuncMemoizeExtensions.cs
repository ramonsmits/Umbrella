using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using nVentive.Umbrella.Collections;

namespace nVentive.Umbrella.Extensions
{
    public static class FuncMemoizeExtensions
    {
        /// <summary>
        /// Parameter less memoizer, used to perform a lazy-cached evaluation. (see http://en.wikipedia.org/wiki/Memoization)
        /// </summary>
        /// <typeparam name="T">The return type to memoize</typeparam>
        /// <param name="func">the function to evaluate</param>
        /// <returns>A memoized value</returns>
        public static Func<T> AsMemoized<T>(this Func<T> func)
        {
            bool isSet = false;
            T value = default(T);

            return () =>
            {
                if (!isSet)
                {
                    value = func();
                    isSet = true;
                }

                return value;
            };
        }

        /// <summary>
        /// Memoizer with one parameter, used to perform a lazy-cached evaluation. (see http://en.wikipedia.org/wiki/Memoization)
        /// </summary>
        /// <typeparam name="T">The return type to memoize</typeparam>
        /// <param name="func">the function to evaluate</param>
        /// <returns>A memoized value</returns>
        public static Func<T, U> AsMemoized<T, U>(this Func<T, U> func)
        {
            Dictionary<T, U> values = new Dictionary<T, U>();

            return (v) =>
            {
                U value;

                if (!values.TryGetValue(v, out value))
                {
                    value = values[v] = func(v);
                }

                return value;
            };
        }

        /// <summary>
        /// Memoizer with one parameter, used to perform a lazy-cached evaluation. (see http://en.wikipedia.org/wiki/Memoization)
        /// </summary>
        /// <typeparam name="T">The return type to memoize</typeparam>
        /// <param name="func">the function to evaluate</param>
        /// <returns>A memoized value</returns>
        public static Func<TKey, TResult> AsLockedMemoized<TKey, TResult>(this Func<TKey, TResult> func)
        {
            var values = new SynchronizedDictionary<TKey, TResult>();

            return (key) =>
            {
                TResult value = default(TResult);

                values.Lock.Write(
                    v => v.TryGetValue(key, out value),
                    v => value = values[key] = func(key)
                );

                return value;
            };
        }

        /// <summary>
        /// Memoizer with one parameter, used to perform a lazy-cached evaluation. (see http://en.wikipedia.org/wiki/Memoization)
        /// </summary>
        /// <typeparam name="T">The return type to memoize</typeparam>
        /// <param name="func">the function to evaluate</param>
        /// <returns>A memoized value</returns>
        public static Func<TArg1, TArg2, TResult> AsLockedMemoized<TArg1, TArg2, TResult>(this Func<TArg1, TArg2, TResult> func)
        {
            var values = new SynchronizedDictionary<Tuple<TArg1, TArg2>, TResult>();

            return (arg1, arg2) =>
            {
                TResult value = default(TResult);

                var tuple = new Tuple<TArg1, TArg2>() { T = arg1, U = arg2 };

                values.Lock.Write(
                    v => v.TryGetValue(tuple, out value),
                    v => value = values[tuple] = func(arg1, arg2)
                );

                return value;
            };
        }

        #region Obsoleted Methods

        [Obsolete("Use AsMemoized Instead.")]
        public static Func<T> Memoize<T>(this Func<T> func)
        {
            return AsMemoized(func);
        }

        [Obsolete("Use AsMemoized Instead.")]
        public static Func<T, U> Memoize<T, U>(this Func<T, U> func)
        {
            return AsMemoized(func);
        }

        [Obsolete("Use AsLockedMemoized Instead.")]
        public static Func<TKey, TResult> LockedMemoize<TKey, TResult>(this Func<TKey, TResult> func)
        {
            return AsLockedMemoized(func);
        }

        [Obsolete("Use AsLockedMemoized Instead.")]
        public static Func<TArg1, TArg2, TResult> LockedMemoize<TArg1, TArg2, TResult>(this Func<TArg1, TArg2, TResult> func)
        {
            return AsLockedMemoized(func);
        }

        #endregion
    }
}
