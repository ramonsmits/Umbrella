using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using nVentive.Umbrella.Provider;

namespace nVentive.Umbrella.Extensions
{
    public static class ProviderExtensions
    {
        public static IProviderExtensions Extensions
        {
            get { return ExtensionsProvider.GetExtensions<IProviderExtensions, DefaultProviderExtensions>(); }
        }

        public static TValue Get<TKey, TValue>(this IProvider<TKey, TValue> provider, TKey key)
        {
            return Extensions.Get<TKey, TValue>(provider, key);
        }

        public static TValue Find<TKey, TValue>(this IProvider<TKey, TValue> provider, TKey key)
        {
            return Extensions.Find<TKey, TValue>(provider, key);
        }

        public static TValue FindOrCreate<TKey, TValue>(this IProvider<TKey, TValue> provider, TKey key, Func<TValue> factory)
        {
            return Extensions.FindOrCreate<TKey, TValue>(provider, key, factory);
        }

        public static void Add<TKey, TValue>(this IProvider<TKey, TValue> provider, TKey key, TValue value)
        {
            Extensions.Add<TKey, TValue>(provider, key, value);
        }

        public static bool Remove<TKey, TValue>(this IProvider<TKey, TValue> provider, TKey key)
        {
            return Extensions.Remove(provider, key);
        }

        public static U Find<TKey, T, U>(this IProvider<TKey, T> provider, TKey key, Func<T, U> to)
        {
            return Extensions.Find<TKey, T, U>(provider, key, to);
        }

        public static U Find<TKey, T, U>(this IProvider<TKey, T> provider, TKey key)
        {
            return Extensions.Find<TKey, T, U>(provider, key);
        }

        public static bool Find<TKey, T, U>(this IProvider<TKey, T> provider, TKey key, out U value)
        {
            return Extensions.Find<TKey, T, U>(provider, key, out value);
        }

        public static bool Find<TKey, T, U>(this IProvider<TKey, T> provider, TKey key, Func<T, U> to, out U value)
        {
            return Extensions.Find<TKey, T, U>(provider, key, to, out value);
        }

        public static U FindOrCreate<TKey, T, U>(this IProvider<TKey, T> provider, TKey key, Func<U> factory)
        {
            return Extensions.FindOrCreate<TKey, T, U>(provider, key, factory);
        }

        public static U FindOrCreate<TKey, T, U>(this IProvider<TKey, T> provider, TKey key, Func<T> factory, Func<U, T> from, Func<T, U> to)
        {
            return Extensions.FindOrCreate<TKey, T, U>(provider, key, factory, from, to);
        }

        public static U FindOrCreate<TKey, T, U>(this IProvider<TKey, T> provider, TKey key, Func<U> factory, Func<U, T> from, Func<T, U> to)
        {
            return Extensions.FindOrCreate<TKey, T, U>(provider, key, factory, from, to);
        }
    }
}
