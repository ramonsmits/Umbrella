using System;
using System.ComponentModel;
using System.Globalization;

namespace nVentive.Umbrella.Conversion
{
    public class TypeConverterConversionStrategy : IConversionStrategy
    {
        #region IConversionStrategy Members

        public bool CanConvert(object value, Type type)
        {
            if (value == null)
            {
                return true;
            }

#if !SILVERLIGHT
            return TypeDescriptor.GetConverter(value.GetType()).CanConvertTo(type) ||
                   TypeDescriptor.GetConverter(type).CanConvertFrom(value.GetType());
#else
            try
            {
                Convert(value, type);
                return true;
            }
            catch (Exception)
            {
                // We can't be very smart here, unfortunately...
                return false;
            }
#endif
        }

        public object Convert(object value, Type type)
        {
            if (value == null)
            {
                return null;
            }

#if !SILVERLIGHT
            var valueTypeConverter = TypeDescriptor.GetConverter(value.GetType());

            return valueTypeConverter.CanConvertTo(type)
                       ? valueTypeConverter.ConvertTo(value, type)
                       : TypeDescriptor.GetConverter(type).ConvertFrom(value);
#else
            return System.Convert.ChangeType(value, type, CultureInfo.CurrentCulture);
#endif        
        }

        #endregion
    }
}