using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella.Sources;

namespace nVentive.Umbrella.Tests.Sources
{
    public class MessageSourceFixture
    {
        [Fact]
        public void Get()
        {
            int i = 0;

            ISource<int> source = new MessageSource<int>(() => 1, value => i = value);

            Assert.Equal(1, source.Value);
        }

        [Fact]
        public void Set()
        {
            int i = 0;

            ISource<int> source = new MessageSource<int>(() => 1, value => i = value);

            source.Value = 2;

            Assert.Equal(2, i);
        }
    }
}
