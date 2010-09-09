using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Validation
{
    public class ValidationExtensionPoint<T> : ExtensionPoint<T>
    {
        public ValidationExtensionPoint(T value)
            : base(value)
        {
        }
    }
}