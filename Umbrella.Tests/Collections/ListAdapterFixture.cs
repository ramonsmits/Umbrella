using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nVentive.Umbrella.Collections;
using Xunit;

namespace nVentive.Umbrella.Tests.Collections
{
    public class ListAdapterFixture
    {
        private List<int> adaptee;
        private IList<string> adapter;

        public ListAdapterFixture()
        {
            adaptee = new List<int> { 1, 3, 4 };
         
            adapter = new ListAdapter<int, string>(
                adaptee,
                Funcs<string,int>.Convert,
                Funcs<int,string>.Convert);
        }

        [Fact]
        public void IndexOf()
        {
            Assert.Equal(1, adapter.IndexOf("3"));
        }

        [Fact]
        public void Insert()
        {
            adapter.Insert(1, "2");

            Assert.Equal(4, adaptee.Count);
            Assert.Equal(2, adaptee[1]);
        }

        [Fact]
        public void RemoveAt()
        {
            adapter.RemoveAt(1);

            Assert.Equal(2, adaptee.Count);
            Assert.Equal(4, adaptee[1]);
        }

        [Fact]
        public void Indexer()
        {
            Assert.Equal("3", adapter[1]);

            adapter[1] = "5";

            Assert.Equal("5", adapter[1]);
        }
    }
}
