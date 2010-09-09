using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Tests.Collections
{
    public class CollectionExtensionsFixture
    {
        private ICollection<int> collection;

        public CollectionExtensionsFixture()
        {
            collection = new List<int>();
        }

        [Fact]
        public void AddRange()
        {
            collection.AddRange(new int[] { 1, 2 });

            Assert.Equal(2, collection.Count);
            Assert.Equal(1, collection.ElementAt(0));
            Assert.Equal(2, collection.ElementAt(1));
        }

        [Fact]
        public void Remove()
        {
            collection.AddRange(new int[] { 1, 2, 3, 4 });

            collection.Remove(item => item % 2 == 0);

            Assert.Equal(2, collection.Count);
            Assert.Equal(1, collection.ElementAt(0));
            Assert.Equal(3, collection.ElementAt(1));
        }

        [Fact]
        public void Adapt()
        {
            ICollection<string> adapter = collection.Adapt<int, string>();

            Assert.NotNull(adapter);
        }

        [Fact]
        public void ReplaceWith()
        {
            collection.AddRange(new int[] { 1, 2 });

            collection.ReplaceWith(new int[] { 3, 4 });

            Assert.Equal(2, collection.Count);
            Assert.Equal(3, collection.ElementAt(0));
            Assert.Equal(4, collection.ElementAt(1));
        }

        [Fact]
        public void Subscribe()
        {
            IDisposable disposable = collection.Subscribe(1);

            Assert.NotNull(disposable);
            Assert.Equal(1, collection.Count);

            disposable.Dispose();

            Assert.Empty(collection);
        }

        [Fact]
        public void AddDistinct()
        {
            collection.AddDistinct(1);
            collection.AddDistinct(2);
            collection.AddDistinct(2);
            collection.AddDistinct(3);
            collection.AddDistinct(5);
            collection.AddDistinct(4);
            collection.AddDistinct(4);

            Assert.Equal(5, collection.Count);
            Assert.Equal(1, collection.ElementAt(0));
            Assert.Equal(2, collection.ElementAt(1));
            Assert.Equal(3, collection.ElementAt(2));
            Assert.Equal(5, collection.ElementAt(3));
            Assert.Equal(4, collection.ElementAt(4));

        }
    }
}
