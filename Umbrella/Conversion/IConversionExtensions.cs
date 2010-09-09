using System;

namespace nVentive.Umbrella.Conversion
{
    public interface IConversionExtensions
    {
        ConversionExtensionPoint Conversion(object value);

        T To<T>(ConversionExtensionPoint extensionPoint);
        object To(ConversionExtensionPoint extensionPoint, Type type);
    }
}