using System;
using nVentive.Umbrella.Conversion;

namespace nVentive.Umbrella.Extensions
{
    public static class ConversionExtensions
    {
        public static IConversionExtensions Extensions
        {
            get { return ExtensionsProvider.Get<IConversionExtensions, DefaultConversionExtensions>(); }
        }

        public static ConversionExtensionPoint Conversion(this object instance)
        {
            return Extensions.Conversion(instance);
        }

        public static T To<T>(this ConversionExtensionPoint extensionPoint)
        {
            return Extensions.To<T>(extensionPoint);
        }

        public static object To(this ConversionExtensionPoint extensionPoint, Type type)
        {
            return Extensions.To(extensionPoint, type);
        }
    }
}