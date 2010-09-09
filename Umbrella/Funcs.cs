using System;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella
{
    public static class Funcs<T>
    {
        public static readonly Func<T, object> CastFrom = Funcs<T, object>.Cast;
        public static readonly Func<object, T> CastTo = Funcs<object, T>.Cast;
        public static readonly Func<T> CreateInstance = Funcs<T, T>.CreateInstance;
        public static readonly Func<T> Default = () => default(T);

        public static Func<T, bool> IsDefault
        {
            get { return item => item.Extensions().IsDefault(); }
        }

        public static Func<T, bool> IsNotDefault
        {
            get { return IsDefault.Not(); }
        }
    }

    public static class Funcs<T, U>
    {
        public static readonly Func<T, U> Cast = item => (U) (object) item;

        public static readonly Func<T, U> Convert = item => item.Conversion().To<U>();

        public static readonly Func<T> CreateInstance = () => typeof (U).New<T>();
    }

    public static class NullableFuncs<T>
        where T : struct
    {
        public static readonly Func<T?, T> FromNullable = item => item.GetValueOrDefault();
        public static readonly Func<T, T?> ToNullable = item => item;
    }
}