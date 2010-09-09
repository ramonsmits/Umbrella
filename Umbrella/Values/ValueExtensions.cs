using System;
using nVentive.Umbrella.Events;
using nVentive.Umbrella.Sources;
using nVentive.Umbrella.Values;

namespace nVentive.Umbrella.Extensions
{
    public static class ValueExtensions
    {
        public static T Get<T>(this IValue<T> instance)
        {
            return instance.Get.Send();
        }

        public static void Set<T>(this IValue<T> instance, T value)
        {
            instance.Set.Send(value);
        }

        public static IDisposable Bind<T>(this IValue<T> first, IValue<T> second)
        {
            return new ValueBinding<T>(first, second);
        }

        public static IDisposable Observe<T>(this IValue<T> value, EventHandler<EventArgs> handler)
        {
            return ((IObservable) value.Get).Observe(handler);
        }

        public static IValue<T> ToValue<T>(this ISource<T> source)
        {
            return new Value<T>(source);
        }

        public static ISource<T> ToSource<T>(this IValue<T> value)
        {
            return new ValueSource<T>(value);
        }
    }
}