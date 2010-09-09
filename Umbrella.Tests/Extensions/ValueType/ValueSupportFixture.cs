using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using nVentive.Umbrella.Extensions;
using nVentive.Umbrella.Extensions.ValueType;
using Xunit;

namespace nVentive.Umbrella.Tests.Extensions.ValueType
{
    public class ValueSupportFixture
    {
        [Fact]
        public void Enum_Add()
        {
            BindingFlags flags = BindingFlags.Public;
            flags = flags.Add(BindingFlags.NonPublic);

            Assert.Equal(BindingFlags.Public | BindingFlags.NonPublic, flags);
        }

        [Fact]
        public void Enum_Remove()
        {
            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic;
            flags = flags.Substract(BindingFlags.NonPublic);

            Assert.Equal(BindingFlags.Public, flags);
        }

        [Fact]
        public void Enum_ContainsAll()
        {
            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic;

            Assert.True(flags.ContainsAll(BindingFlags.Public));
            Assert.True(flags.ContainsAll(BindingFlags.NonPublic));
            Assert.True(flags.ContainsAll(BindingFlags.Public | BindingFlags.NonPublic));

            Assert.False(flags.ContainsAll(BindingFlags.Public | BindingFlags.Instance));
            Assert.False(flags.ContainsAll(BindingFlags.Instance));

        }

        [Fact]
        public void Enum_ContainsAny()
        {
            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic;

            Assert.True(flags.ContainsAny(BindingFlags.Public));
            Assert.True(flags.ContainsAny(BindingFlags.NonPublic));
            Assert.True(flags.ContainsAny(BindingFlags.Public | BindingFlags.NonPublic));
            Assert.True(flags.ContainsAny(BindingFlags.Public | BindingFlags.Instance));

            Assert.False(flags.ContainsAny(BindingFlags.Instance));
        }
    }
}
