using System;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Serialization
{
    public class SerializationExtensionPoint<T> : ExtensionPoint<T>
    {
        public SerializationExtensionPoint(T value)
            : base(value)
        {
        }

        public SerializationExtensionPoint(Type type)
            : base(type)
        {
        }
    }
}