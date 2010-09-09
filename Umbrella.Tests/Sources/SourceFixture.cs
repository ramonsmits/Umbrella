using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella.Extensions;
using nVentive.Umbrella.Sources;

namespace nVentive.Umbrella.Tests.Sources
{
    public class SourceFixture
    {
        private ISource<int> source = new Source<int>();

        [Fact]
        public void Default()
        {
            Assert.Equal(default(int), source.Value);
        }

        [Fact]
        public void Get()
        {
            source = new Source<int>(1);

            Assert.Equal(1, source.Value);
        }

        [Fact]
        public void Set()
        {
            source.Value = 1;

            Assert.Equal(1, source.Value);
        }
    }
}
