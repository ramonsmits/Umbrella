using System;

namespace nVentive.Umbrella.Extensions
{
    public static class ObjectExtensions
    {
        public static ExtensionPoint<T> Extensions<T>(this T value)
        {
            return new ExtensionPoint<T>(value);
        }

        public static bool IsDefault<T>(this ExtensionPoint<T> extensionPoint)
        {
            return Equals(extensionPoint.ExtendedValue, default(T));
        }

        public static void Dispose<T>(this ExtensionPoint<T> extensionPoint)
        {
            var disposable = extensionPoint.ExtendedValue as IDisposable;

            disposable.Maybe(d => d.Dispose());
        }

        public static IDisposable Using<T>(this ExtensionPoint<T> extensionPoint)
        {
            var disposable = extensionPoint.ExtendedValue as IDisposable;

            return disposable ?? NullDisposable.Instance;
        }

        public static void Maybe<TInstance>(this TInstance instance, Action action)
        {
            if (instance != null)
            {
                action();
            }
        }

        public static void Maybe<TInstance>(this TInstance instance, Action<TInstance> action)
        {
            if (instance != null)
            {
                action(instance);
            }
        }

        public static TResult Maybe<TResult, TInstance>(this TInstance instance, Func<TInstance, TResult> function)
        {
            return Maybe(instance, function, default(TResult));
        }

        public static TResult Maybe<TResult, TInstance>(this TInstance instance, Func<TInstance, TResult> function, TResult defaultValue)
        {
            return instance == null ? defaultValue : function(instance);
        }
    }
}
