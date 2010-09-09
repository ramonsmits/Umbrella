using System;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Reflection
{
    public class ReflectionExtensionPoint<T> : ExtensionPoint<T>, IReflectionExtensionPoint, IReflectionExtensionPoint<T>
    {
        public ReflectionExtensionPoint(Type type)
            : base(type)
        {
        }

        public ReflectionExtensionPoint(T value)
            : base(value)
        {
        }
    }
}