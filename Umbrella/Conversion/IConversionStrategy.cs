using System;

namespace nVentive.Umbrella.Conversion
{
    public interface IConversionStrategy
    {
        bool CanConvert(object value, Type type);
        object Convert(object value, Type type);
    }
}