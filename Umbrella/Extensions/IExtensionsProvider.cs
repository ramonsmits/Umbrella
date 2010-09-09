using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nVentive.Umbrella.Extensions
{
    public interface IExtensionsProvider
    {
        T FindExtensions<T>()
            where T : class;

        T GetExtensions<T>(Func<T> factory, Func<Type, T> configFactory)
            where T : class;

        T GetExtensions<T, TDefault>(bool checkConfigFirst)
            where T : class
            where TDefault : T, new();

        T GetExtensions<T, TDefault>()
            where T : class
            where TDefault : T, new();

        void Register<T>(T instance);
    }
}
