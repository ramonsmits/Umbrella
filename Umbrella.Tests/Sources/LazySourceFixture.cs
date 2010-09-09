using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella.Sources;

namespace nVentive.Umbrella.Tests.Sources
{
    public class LazySourceFixture
    {
        [Fact]
        public void Get()
        {
            bool called = false;

            ISource<int> source = new LazySource<int>(() => { called = true; return 1; });

            Assert.False(called);
            Assert.Equal(1, source.Value);
            Assert.True(called);
        }

        [Fact]
        public void Set()
        {
            bool called = false;

            ISource<int> source = new LazySource<int>(() => { called = true; return 1; });

            source.Value = 2;

            Assert.Equal(2, source.Value);
            Assert.False(called);
        }

        [Fact]
        public void Behavior_Null()
        {
            bool called = false;

            ISource<string> source = new LazySource<string>(LazyBehavior.Null, () => { called = true; return "A"; });

            source.Value = null;

            Assert.Equal("A", source.Value);
            Assert.True(called);
        }

        [Fact]
        public void Behavior_Default()
        {
            bool called = false;

            ISource<int> source = new LazySource<int>(LazyBehavior.Default, () => { called = true; return 1; });

            source.Value = 0;

            Assert.Equal(1, source.Value);
            Assert.True(called);
        }
    }
}
