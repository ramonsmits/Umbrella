using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella.Sources;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Tests.Sources
{
    public class EnumerableSourceFixture
    {
        [Fact]
        public void Get()
        {
            ILazySource<IEnumerable<int>> lazySource = new LazySource<IEnumerable<int>>(() => Enumerable.Range(1, 5));

            ISource<IEnumerable<int>> source = new EnumerableSource<int>(lazySource);

            Assert.NotNull(source.Value);
            Assert.False(lazySource.IsLoaded);
            
            source.Value.ForEach();

            Assert.True(lazySource.IsLoaded);
            Assert.True(source.Value.SequenceEqual(lazySource.Value));
        }
    }
}
