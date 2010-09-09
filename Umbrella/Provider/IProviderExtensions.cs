using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nVentive.Umbrella.Provider
{
    public interface IProviderExtensions
    {
        bool Find<TKey, TValue>(IProvider<TKey, TValue> provider, TKey key, out TValue value);
        TValue Find<TKey, TValue>(IProvider<TKey, TValue> provider, TKey key);
        TValue FindOrCreate<TKey, TValue>(IProvider<TKey, TValue> provider, TKey key, Func<TValue> factory);
        bool FindOrCreate<TKey, TValue>(IProvider<TKey, TValue> provider, TKey key, Func<TValue> factory, out TValue value);

        TValue Get<TKey, TValue>(IProvider<TKey, TValue> provider, TKey key);

        void Add<TKey, TValue>(IProvider<TKey, TValue> provider, TKey key, TValue value);
        bool Remove<TKey, TValue>(IProvider<TKey, TValue> provider, TKey key);

        //TODO Move into ProviderAdapter + DictionaryAdapter?
        U Find<TKey, T, U>(IProvider<TKey, T> provider, TKey key, Func<T, U> to);
        U Find<TKey, T, U>(IProvider<TKey, T> provider, TKey key);
        
        bool Find<TKey, T, U>(IProvider<TKey, T> provider, TKey key, out U value);
        bool Find<TKey, T, U>(IProvider<TKey, T> provider, TKey key, Func<T, U> to, out U value);
        
        U FindOrCreate<TKey, T, U>(IProvider<TKey, T> provider, TKey key, Func<U> factory);
        U FindOrCreate<TKey, T, U>(IProvider<TKey, T> provider, TKey key, Func<U> factory, Func<U, T> from, Func<T, U> to);

        U FindOrCreate<TKey, T, U>(IProvider<TKey, T> provider, TKey key, Func<T> factory, Func<U, T> from, Func<T, U> to);
    }
}
