using System;
using nVentive.Umbrella.Messages;
using nVentive.Umbrella.Sources;

namespace nVentive.Umbrella.Extensions
{
    public static class SourceExtensions
    {
        public static ISource<T> AsReadOnly<T>(this ISource<T> source)
        {
            return new ReadOnlySource<T>(source);
        }

        public static ISource<T> AsReadOnly<T>(this ISource<T> source, bool throwOnSet)
        {
            return new ReadOnlySource<T>(source, throwOnSet);
        }

        public static IMessage<Null, T> ToGetMessage<T>(this ISource<T> source)
        {
            Func<T> func = () => source.Value;

            return func.ToMessage();
        }

        public static IMessage<T, Null> ToSetMessage<T>(this ISource<T> source)
        {
            Action<T> action = value => source.Value = value;

            return action.ToMessage();
        }

        public static ISource<U> Adapt<T, U>(this ISource<T> source)
        {
            return Adapt(source, Funcs<U, T>.Convert, Funcs<T, U>.Convert);
        }

        public static ISource<U> Adapt<T, U>(this ISource<T> source, Func<U, T> from, Func<T, U> to)
        {
            return new SourceAdapter<T, U>(source, from, to);
        }

        public static ISource<T?> Adapt<T>(this ISource<T> source)
            where T : struct
        {
            return new SourceAdapter<T, T?>(source, NullableFuncs<T>.FromNullable, NullableFuncs<T>.ToNullable);
        }

        public static ISource<T> Adapt<T>(this ISource<T?> source)
            where T : struct
        {
            return new SourceAdapter<T?, T>(source, NullableFuncs<T>.ToNullable, NullableFuncs<T>.FromNullable);
        }

        public static IDisposableSource<T> ToDisposable<T>(this ISource<T> source)
        {
            return new DisposableSource<T>(source);
        }

        public static IDisposableSource<T> ToDisposable<T>(this ISource<T> source, Action action)
        {
            return new DisposableSource<T>(source, action);
        }
    }
}