using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nVentive.Umbrella.Validation
{
    public interface IValidationExtensions
    {
        ValidationExtensionPoint<T> Validation<T>(T value);

        T NotNull<T>(ValidationExtensionPoint<T> extensionPoint, string name);

        T Found<T>(ValidationExtensionPoint<T> extensionPoint);

        void NotSupported<T>(ValidationExtensionPoint<T> extensionPoint);
    }
}
