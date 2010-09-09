using System;
using System.Collections.Generic;
using System.Linq;

namespace nVentive.Umbrella.Extensions
{
    public static class DictionaryExtensions
    {
        public static TValue FindOrCreate<TKey, TValue>(this IDictionary<TKey, TValue> items, TKey key,
                                                        Func<TValue> factory)
        {
            TValue value;

            if (!items.TryGetValue(key, out value))
            {
                value = factory();
                items.Add(key, value);
            }

            return value;
        }

        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            return GetValueOrDefault(dictionary, key, default(TValue));
        }

        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
        {
            var value = defaultValue;

            if (dictionary != null)
            {
                if (!dictionary.TryGetValue(key, out value))
                    value = defaultValue;
            }

            return value;
        }

        public static IEnumerable<TKey> RemoveKeys<TKey, TValue>(this IDictionary<TKey, TValue> items, IEnumerable<TKey> range)
        {
            return range.Where(k => items.Remove(k)).ToList();
        }
    }
}