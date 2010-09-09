using System;
using nVentive.Umbrella.Containers;
using nVentive.Umbrella.Sources;
using nVentive.Umbrella.Values;

namespace nVentive.Umbrella.Extensions
{
    public static class ContainerExtensions
    {
        public static T Get<T>(this ContainerExtensionPoint container, string key)
        {
            return container.ContentType == ContentType.Source
                       ? GetSource<T>(container.ExtendedValue, key).Value
                       : GetValue<T>(container.ExtendedValue, key).Get();
        }

        public static T Get<T>(this ContainerExtensionPoint container, string key, Func<T> factory)
        {
            return container.ContentType == ContentType.Source
                       ? GetSource(container.ExtendedValue, key, factory).Value
                       : GetValue(container.ExtendedValue, key, factory).Get();
        }

        public static void Set<T>(this ContainerExtensionPoint container, string key, T value)
        {
            if (container.ContentType == ContentType.Source)
            {
                GetSource<T>(container.ExtendedValue, key).Value = value;
            }
            else
            {
                GetValue<T>(container.ExtendedValue, key).Set(value);
            }
        }

        public static void Set<T>(this ContainerExtensionPoint container, string key, Func<T> factory, T value)
        {
            if (container.ContentType == ContentType.Source)
            {
                GetSource(container.ExtendedValue, key, factory).Value = value;
            }
            else
            {
                GetValue(container.ExtendedValue, key, factory).Set(value);
            }
        }

        public static IValue<T> GetValue<T>(this IContainer container, string key)
        {
            return GetValue(
                container,
                key,
                Funcs<IValue<T>, Value<T>>.CreateInstance);
        }

        public static ILazyValue<T> GetValue<T>(this IContainer container, string key, Func<T> factory)
        {
            return (ILazyValue<T>) container.Values.FindOrCreate(
                                       key,
                                       () => new LazyValue<T>(factory));
        }

        public static IValue<T> GetValue<T>(this IContainer container, string key, Func<IValue<T>> factory)
        {
            return (IValue<T>) container.Values.FindOrCreate(
                                   key,
                                   () => factory());
        }

        public static ISource<T> GetSource<T>(this IContainer container, string key)
        {
            return GetSource(
                container,
                key,
                Funcs<ISource<T>, Source<T>>.CreateInstance);
        }

        public static ILazySource<T> GetSource<T>(this IContainer container, string key, Func<T> factory)
        {
            return (ILazySource<T>) container.Values.FindOrCreate(
                                        key,
                                        () => new LazySource<T>(factory));
        }

        public static ISource<T> GetSource<T>(this IContainer container, string key, Func<ISource<T>> factory)
        {
            return (ISource<T>) container.Values.FindOrCreate(
                                    key,
                                    () => factory());
        }
    }
}