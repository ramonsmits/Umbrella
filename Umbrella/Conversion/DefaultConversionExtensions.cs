using System;
using System.Collections.Generic;
using System.Linq;

namespace nVentive.Umbrella.Conversion
{
    public class DefaultConversionExtensions : IConversionExtensions
    {
        private readonly List<IConversionStrategy> strategies;

        public DefaultConversionExtensions()
        {
            strategies = new List<IConversionStrategy>
                             {
                                 new EnumConversionStrategy(),
                                 new TypeConverterConversionStrategy()
                             };
        }

        protected virtual IEnumerable<IConversionStrategy> Strategies
        {
            get { return strategies; }
        }

        #region IConversionExtensions Members

        public ConversionExtensionPoint Conversion(object value)
        {
            return new ConversionExtensionPoint(value);
        }

        public T To<T>(ConversionExtensionPoint extensionPoint)
        {
            return (T) To(extensionPoint, typeof (T));
        }

        public object To(ConversionExtensionPoint extensionPoint, Type type)
        {
            IConversionStrategy strategy = Strategies.First(item => item.CanConvert(extensionPoint.ExtendedValue, type));

            return strategy.Convert(extensionPoint.ExtendedValue, type);
        }

        #endregion
    }
}