using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella.Sources;

namespace nVentive.Umbrella.Tests.Sources
{
    public class EnvironmentSourceFixture
    {
        [Fact]
        public void Get()
        {
            Environment.SetEnvironmentVariable("A", "1");

            ISource<string> source = new EnvironmentSource("A");

            Assert.Equal("1", source.Value);
        }

        [Fact]
        public void Set()
        {
            ISource<string> source = new EnvironmentSource("A");

            source.Value = "2";

            Assert.Equal("2", Environment.GetEnvironmentVariable("A"));
        }
    }
}
