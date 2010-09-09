using System;

namespace nVentive.Umbrella.Extensions
{
    public interface IExtensionPoint
    {
        object ExtendedValue { get; }
        Type ExtendedType { get; }
    }
}