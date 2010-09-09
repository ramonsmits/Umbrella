using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nVentive.Umbrella.Extensions;
using Xunit;
using System.Collections;

namespace nVentive.Umbrella.Tests.Collections
{
    public class EnumerableExtensionsFixture
    {
        private IEnumerable<string> items = new List<string> { "1", "2", "3", "4", "5"};

        [Fact]
        public void ForEach()
        {
            items.ForEach();
        }

        [Fact]
        public void ForEach_Action()
        {
            List<string> actionItems = new List<string>();

            items.ForEach(actionItems.Add);

            Assert.Equal(5, actionItems.Count);
        }

        [Fact]
        public void ForEach_IndexedAction()
        {
            string[] actionItems = new string[5];

            items.ForEach((i, item) => actionItems[i] = item);

            Assert.Equal("1", actionItems[0]);
            Assert.Equal("2", actionItems[1]);
            Assert.Equal("3", actionItems[2]);
            Assert.Equal("4", actionItems[3]);
            Assert.Equal("5", actionItems[4]);
        }

        [Fact]
        public void None()
        {
            Assert.False(items.None(item => item == "1"));

            Assert.True(items.None(item => item == "6"));
        }

        [Fact]
        public void Empty()
        {
            Assert.True(new List<string>().Empty());

            Assert.False(items.Empty());
        }

        [Fact]
        public void ToArray()
        {
            object[] objectItems = ((IEnumerable)items).ToObjectArray();

            Assert.Equal("1", objectItems[0]);
            Assert.Equal("2", objectItems[1]);
            Assert.Equal("3", objectItems[2]);
            Assert.Equal("4", objectItems[3]);
            Assert.Equal("5", objectItems[4]);
        }

        [Fact]
        public void Pair()
        {
            IEnumerable<string> otherItems = new List<string> { "6", "7", "8", "9", "10" };

            IEnumerable<Pair<string>> pairedItems = items.Pair(otherItems);

            Assert.Equal(5, pairedItems.Count());

            Assert.Equal("1", pairedItems.First().X);
            Assert.Equal("6", pairedItems.First().Y);
        }

        [Fact]
        public void IndexOf()
        {
            Assert.Equal(2, items.IndexOf("3"));
        }

        [Fact]
        public void SingleOrDefault_Empty()
        {
            var items = new List<int>();

            Assert.Null(items.SingleOrDefault(item => item.ToString()));
        }

        [Fact]
        public void SingleOrDefault()
        {
            var items = new List<int> { 1 };

            Assert.Equal("1", items.SingleOrDefault(item => item.ToString()));
        }
    }
}
