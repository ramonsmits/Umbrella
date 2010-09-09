using System;
using nVentive.Umbrella.Validation;

namespace nVentive.Umbrella.Extensions
{
    public static class ValidationExtensions
    {
        public static ValidationExtensionPoint<T> Validation<T>(this T value) where T : class
        {
            return new ValidationExtensionPoint<T>(value);
        }

        public static T NotNull<T>(this ValidationExtensionPoint<T> extensionPoint, string name) where T : class
        {
            if (extensionPoint.ExtendedValue == null)
            {
                throw new ArgumentNullException(name);
            }

            return extensionPoint.ExtendedValue;
        }

        public static T Found<T>(this ValidationExtensionPoint<T> extensionPoint) where T : class
        {
            if (extensionPoint.ExtendedValue == null)
            {
                throw new NotFoundException();
            }

            return extensionPoint.ExtendedValue;
        }

        public static void NotSupported<T>(this ValidationExtensionPoint<T> extensionPoint) where T : class
        {
            throw new NotSupportedException();
        }
    }
}