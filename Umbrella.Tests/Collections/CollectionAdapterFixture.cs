using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella.Collections;

namespace nVentive.Umbrella.Tests.Collections
{
    public class CollectionAdapterFixture
    {
        private List<int> adaptee;
        private ICollection<string> adapter;

        public CollectionAdapterFixture()
        {
            adaptee = new List<int>();

            adapter = new CollectionAdapter<int, string>(
                adaptee,
                Funcs<string, int>.Convert,
                Funcs<int, string>.Convert);
        }

        [Fact]
        public void Add()
        {
            adapter.Add("1");

            Assert.Equal(1, adaptee[0]);
        }

        [Fact]
        public void Clear()
        {
            adaptee.Add(1);

            adapter.Clear();

            Assert.Empty(adaptee);
        }

        [Fact]
        public void Contains()
        {
            adaptee.Add(1);

            Assert.True(adapter.Contains("1"));
        }

        [Fact]
        public void CopyToArray()
        {
            adaptee.Add(1);

            string[] array = new string[1];

            adapter.CopyTo(array, 0);

            Assert.Equal(1, array.Length);
            Assert.Equal("1", array[0]);
        }

        [Fact]
        public void Count()
        {
            adaptee.Add(1);

            Assert.Equal(1, adapter.Count);
        }

        [Fact]
        public void IsReadOnly()
        {
            Assert.False(adapter.IsReadOnly);
        }

        [Fact]
        public void Remove()
        {
            adaptee.Add(1);

            adapter.Remove("1");

            Assert.Empty(adaptee);
        }

        [Fact]
        public void Enumerable()
        {
            adaptee.Add(1);
            adaptee.Add(2);

            Assert.Equal("1", adapter.ElementAt(0));
            Assert.Equal("2", adapter.ElementAt(1));
        }
    }
}
