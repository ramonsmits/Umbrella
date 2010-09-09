using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella.Collections;

namespace nVentive.Framework.Tests.Collections
{
    public class LazyListFixture
    {
        [Fact]
        public void CanCreate()
        {
            var list = new LazyList<int>(() => new List<int>());
            
            Assert.NotNull(list);
        }

        [Fact]
        public void ShouldNotCallFactoryOnConstruction()
        {
            bool called = false;
            var list = new LazyList<int>(() => { called = true; return new List<int>(); });

            Assert.False(called);
        }

        [Fact]
        public void ShouldReturnInnerElements()
        {
            var innerList = new List<int> { 1, 2, 3 };

            var list = new LazyList<int>(() => innerList);

            Assert.True(innerList.SequenceEqual(list));
        }
    }
}
