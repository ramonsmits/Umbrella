namespace nVentive.Umbrella.Extensions
{
    public interface IExtensionPoint<T> : IExtensionPoint
    {
        new T ExtendedValue { get; }
    }
}