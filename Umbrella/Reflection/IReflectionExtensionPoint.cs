using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Reflection
{
    public interface IReflectionExtensionPoint : IExtensionPoint
    {
    }

    public interface IReflectionExtensionPoint<T> : IReflectionExtensionPoint
    {
    }
}