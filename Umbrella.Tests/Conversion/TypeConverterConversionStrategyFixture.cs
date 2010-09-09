using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella.Extensions;

namespace nVentive.Framework.Tests.Conversion
{
    public class TypeConverterConversionStrategyFixture
    {
        [Fact]
        public void CanConvertInt32ToString()
        {
            Assert.Equal("1", 1.Conversion().To<string>());
        }

        [Fact]
        public void CanConvertStringToInt32()
        {
            Assert.Equal(1, "1".Conversion().To<int>());
        }
    }
}
