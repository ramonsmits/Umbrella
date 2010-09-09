using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella.Extensions;
using System.ComponentModel;

namespace nVentive.Umbrella.Tests.Conversion
{
    public class ConversionExtensionsFixture
    {
        [Fact]
        public void Conversion()
        {
            int i = 1;

            Assert.NotNull(i.Conversion());
            Assert.Equal(i, i.Conversion().ExtendedValue);
        }

        [Fact]
        public void Convert()
        {
            string s = "1";

            Assert.Equal(1, s.Conversion().To<int>());
        }

        [Fact]
        public void Convert_Type()
        {
            string s = "1";

            Assert.Equal(1, s.Conversion().To(typeof(int)));
        }
    }
}
