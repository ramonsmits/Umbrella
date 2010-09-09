using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella.Collections;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Tests.Collections
{
    public class ListDecoratorFixture
    {
        [Fact]
        public void IndexOf()
        {
            var decorator = new ListDecorator<int>() { 1, 2, 3 };

            Assert.Equal(2, decorator.IndexOf(3));
        }

        [Fact]
        public void Insert()
        {
            var decorator = new ListDecorator<int>() { 1, 2, 3 };

            decorator.Insert(1, 5);

            Assert.Equal(5, decorator[1]);
        }

        [Fact]
        public void RemoveAt()
        {
            var decorator = new ListDecorator<int> { 1, 2, 3 };

            decorator.RemoveAt(1);

            Assert.Equal(2, decorator.Count);
        }

        [Fact]
        public void Clear()
        {
            var decorator = new ListDecorator<int> { 1, 2, 3 };

            decorator.Clear();

            Assert.True(decorator.Empty());
        }

        [Fact]
        public void Contains()
        {
            var decorator = new ListDecorator<int> { 1, 2, 3 };

            Assert.True(decorator.Contains(2));
        }

        [Fact]
        public void CopyTo()
        {
            var decorator = new ListDecorator<int> { 1, 2, 3 };

            int[] array = new int[3];

            decorator.CopyTo(array, 0);

            Assert.True(decorator.SequenceEqual(array));
        }

        [Fact]
        public void IsReadOnly()
        {
            var decorator = new ListDecorator<int> { 1, 2, 3 };

            Assert.False(decorator.IsReadOnly);
        }

        [Fact]
        public void Remove()
        {
            var decorator = new ListDecorator<int> { 1, 2, 3 };

            decorator.Remove(1);

            Assert.Equal(2, decorator.Count);
        }
    }
}
