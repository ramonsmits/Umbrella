using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella.Conversion;
using nVentive.Umbrella.Extensions;
using System.ComponentModel;

namespace nVentive.Umbrella.Tests.Conversion
{
    public class EnumConversionStrategyFixture
    {
        [Fact]
        public void EnumFromString()
        {
            Assert.Equal(Status.Verified, "Verified".Conversion().To<Status>());
            Assert.Equal(Status.Verified, "VER".Conversion().To<Status>());
        }

        [Fact]
        public void EnumFromUnknownString()
        {
            Assert.Equal(StatusWithUnkwown.Unknown, "Error".Conversion().To<StatusWithUnkwown>());
        }

        [Fact]
        public void EnumFromInvalidStringThrowsInvalidCastException()
        {
            Assert.Throws<FormatException>(() => "Invalid".Conversion().To<Status>());
        }

        [Fact]
        public void StringFromEnum()
        {
            Assert.Equal("Cancelled", Status.Cancelled.Conversion().To<string>());
            Assert.Equal("VER", Status.Verified.Conversion().To<string>());
        }

        public enum Status
        {
            [Description("VER")]
            Verified,
            Cancelled
        }

        public enum StatusWithUnkwown
        {
            [Description("?")]
            Unknown,
            [Description("VER")]
            Verified,
            Cancelled
        }
    }
}
