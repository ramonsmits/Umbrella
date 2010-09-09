using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella.Serialization;

namespace nVentive.Framework.Tests.Serialization
{
    public class SerializationExtensionPointFixture
    {
        [Fact]
        public void Instance()
        {
            int instance = 1;
            var extensionPoint = new SerializationExtensionPoint<int>(instance);

            Assert.Equal(instance, extensionPoint.ExtendedValue);
            Assert.Equal(typeof(int), extensionPoint.ExtendedType);
        }

        [Fact]
        public void Type()
        {
            var extensionPoint = new SerializationExtensionPoint<object>(typeof(int));

            Assert.Null(extensionPoint.ExtendedValue);
            Assert.Same(typeof(int), extensionPoint.ExtendedType);
        }

    }
}
