using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Equality
{
    public class EqualityExtensionPoint<T> : ExtensionPoint<T>
    {
        public EqualityExtensionPoint(T value)
            : base(value)
        {
        }
    }
}