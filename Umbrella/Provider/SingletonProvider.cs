using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using nVentive.Umbrella.Extensions;
using nVentive.Umbrella.Threading;

namespace nVentive.Umbrella.Provider
{
    public static class SingletonProvider
    {
        private static readonly SynchronizedProvider<Type, object> provider = new SynchronizedProvider<Type, object>(new Provider<Type, object>());

        public static T Get<T>(Func<T> factory)
            where T : class
        {
            object instance = null;
            
            Type type = typeof(T);
            
            // Provider Extension Methods cannot be used since it calls ExtensionsProvider which in turn calls SingletonProvider
            provider.Lock.Write(
                -1,
                items => items.TryGetValue(type, out instance),
                items => { instance = factory(); items.Add(type, instance); });
            
            return (T)instance;
        }

        public static bool Find<T>(out T instance)
            where T : class
        {
            return provider.Find(typeof(T), out instance);
        }

        public static void Register<T>(T instance)
        {
            provider.Add(typeof(T), instance);
        }
    }
}
