using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using nVentive.Umbrella.Extensions;
using nVentive.Umbrella.Threading;

namespace nVentive.Umbrella.Provider
{
    public class DefaultProviderExtensions : IProviderExtensions
    {
        #region IProviderExtensions Members

        public virtual bool Find<TKey, TValue>(IProvider<TKey, TValue> provider, TKey key, out TValue value)
        {
            var syncProvider = Lock(provider);

            if (syncProvider == null)
            {
                return provider.Items.TryGetValue(key, out value);
            }
            else
            {
                TValue tempValue = default(TValue);

                bool found = syncProvider.Read(items => items.TryGetValue(key, out tempValue));

                value = tempValue;

                return found;
            }
        }

        public virtual bool FindOrCreate<TKey, TValue>(IProvider<TKey, TValue> provider, TKey key, Func<TValue> factory, out TValue value)
        {
            var syncProvider = Lock(provider);

            if (syncProvider == null)
            {
                if (!provider.Items.TryGetValue(key, out value))
                {
                    value = factory();
                    provider.Items.Add(key, value);
                    return false;
                }

                return true;
            }
            else
            {
                TValue tempValue = default(TValue);

                bool found = syncProvider.Write(
                    items => items.TryGetValue(key, out tempValue),
                    items =>
                    {
                        tempValue = factory();
                        items.Add(key, tempValue);
                    });

                value = tempValue;

                return found;
            }
        }

        public TValue Get<TKey, TValue>(IProvider<TKey, TValue> provider, TKey key)
        {
            TValue value;

            if (Find<TKey, TValue>(provider, key, out value))
            {
                return value;
            }
            else
            {
                throw new NotFoundException();
            }
        }

        public TValue Find<TKey, TValue>(IProvider<TKey, TValue> provider, TKey key)
        {
            TValue value;

            Find<TKey, TValue>(provider, key, out value);

            return value;
        }

        public virtual TValue FindOrCreate<TKey, TValue>(IProvider<TKey, TValue> provider, TKey key, Func<TValue> factory)
        {
            TValue value;
            FindOrCreate(provider, key, factory, out value);
            return value;
        }

        public virtual void Add<TKey, TValue>(IProvider<TKey, TValue> provider, TKey key, TValue value)
        {
            TValue tempValue;

            if (FindOrCreate(provider, key, () => value, out tempValue))
            {
                throw new ArgumentException("Already exists");
            }
        }

        public virtual bool Remove<TKey, TValue>(IProvider<TKey, TValue> provider, TKey key)
        {
            var syncProvider = Lock(provider);

            if (syncProvider == null)
            {
                return provider.Items.Remove(key);
            }
            else
            {
                return syncProvider.Write(items => items.Remove(key));
            }
        }

        public U Find<TKey, T, U>(IProvider<TKey, T> provider, TKey key, Func<T, U> to)
        {
            return to(Find<TKey, T>(provider, key));
        }

        public U Find<TKey, T, U>(IProvider<TKey, T> provider, TKey key)
        {
            return Find<TKey, T, U>(provider, key, Funcs<T, U>.Cast);
        }

        public bool Find<TKey, T, U>(IProvider<TKey, T> provider, TKey key, out U value)
        {
            return Find<TKey, T, U>(provider, key, Funcs<T, U>.Cast, out value);
        }

        public bool Find<TKey, T, U>(IProvider<TKey, T> provider, TKey key, Func<T, U> to, out U value)
        {
            T tempValue;

            if (Find<TKey, T>(provider, key, out tempValue))
            {
                value = to(tempValue);
                return true;
            }
            else
            {
                value = default(U);
                return false;
            }
        }

        public U FindOrCreate<TKey, T, U>(IProvider<TKey, T> provider, TKey key, Func<U> factory)
        {
            return FindOrCreate<TKey, T, U>(
                provider,
                key,
                factory,
                Funcs<U, T>.Cast,
                Funcs<T, U>.Cast);
        }

        public U FindOrCreate<TKey, T, U>(IProvider<TKey, T> provider, TKey key, Func<T> factory, Func<U, T> from, Func<T, U> to)
        {
            T tempValue;
            FindOrCreate(provider, key, () => factory(), out tempValue);

            return to(tempValue);
        }

        public U FindOrCreate<TKey, T, U>(IProvider<TKey, T> provider, TKey key, Func<U> factory, Func<U, T> from, Func<T, U> to)
        {
            T tempValue;
            FindOrCreate(provider, key, () => from(factory()), out tempValue);

            return to(tempValue);
        }

        #endregion

        protected ISynchronizableLock<IDictionary<TKey, TValue>> Lock<TKey, TValue>(IProvider<TKey, TValue> provider)
        {
            var syncProvider = provider as ISynchronizable<IDictionary<TKey, TValue>>;

            return syncProvider == null ? null : syncProvider.Lock;
        }
    }
}
