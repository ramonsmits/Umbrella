using System;
using System.Collections.Generic;
using nVentive.Umbrella.Collections;

namespace nVentive.Umbrella.Extensions.ValueType
{
    public static class ValueSupport
    {
        private static readonly SynchronizedDictionary<Type, IValueSupport> support;

        static ValueSupport()
        {
            support = new SynchronizedDictionary<Type, IValueSupport>(
                new Dictionary<Type, IValueSupport>()
                {
                    { typeof(Int32), new Int32Support() },
                    { typeof(Byte), new ByteSupport() }
                }
            );
        }

        public static IValueSupport<T> Get<T>()
        {
            var type = typeof (T);

            if (type.IsEnum)
            {
                support.Lock.Write(
                    d => d.ContainsKey(type), 
                    d => d.Add(type, new EnumSupport<T>())
                );
            }

            return (IValueSupport<T>) Get(type);
        }

        public static IValueSupport Get(object instance)
        {
            return Get(instance.GetType());
        }

        public static IValueSupport Get(Type type)
        {
            foreach (var kvp in support)
            {
                if (kvp.Key == type)
                {
                    return kvp.Value;
                }
            }

            throw new NotSupportedException();
        }
    }
}