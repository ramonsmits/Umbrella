using System;

namespace nVentive.Umbrella.Locator
{
    public static class ServiceLocatorExtensions
    {
        public static T Resolve<T>(this IServiceLocator locator, string name)
        {
            return (T) locator.Resolve(typeof (T), name);
        }

        public static T Resolve<T>(this IServiceLocator locator)
        {
            return Resolve<T>(locator, null);
        }

        public static object Resolve(this IServiceLocator locator, Type type)
        {
            return locator.Resolve(type, null);
        }

        public static bool CanResolve<T>(this IServiceLocator locator, string name)
        {
            return locator.CanResolve(typeof (T), name);
        }

        public static bool CanResolve<T>(this IServiceLocator locator)
        {
            return CanResolve<T>(locator, null);
        }

        public static bool CanResolve(this IServiceLocator locator, Type type)
        {
            return locator.CanResolve(type, null);
        }

        public static T TryResolve<T>(this IServiceLocator locator)
        {
            return locator.CanResolve<T>() ? locator.Resolve<T>() : default(T);
        }
    }
}