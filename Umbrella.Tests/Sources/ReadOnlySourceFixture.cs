using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella.Sources;

namespace nVentive.Umbrella.Tests.Sources
{
    public class ReadOnlySourceFixture
    {
        private ISource<int> source = new ReadOnlySource<int>(new Source<int>(1));

        [Fact]
        public void Get()
        {
            Assert.Equal(1, source.Value);
        }

        [Fact]
        public void Set()
        {
            Assert.Throws<ReadOnlyException>(() => source.Value = 2);
        }
    }
}
