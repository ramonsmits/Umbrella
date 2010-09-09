using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using System.Collections;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Tests
{
    public class KeyFixture
    {
        [Fact]
        public void Ctor()
        {
            IEnumerable items = new object[] { 1, "A", null};

            Key key = new Key(items);
        }

        [Fact]
        public void Items()
        {
            Key key = new Key(1, "A", null);

            Assert.Equal(1, key.Items[0]);
            Assert.Equal("A", key.Items[1]);
            Assert.Null(key.Items[2]);
        }

        [Fact]
        public void OverridesGetHashCode()
        {
            var values = new object[] { 1, "A", null };
            Key key = new Key(values);

            int expectedHash = EqualityExtensions.Equality<Key>(key).GetHashCode(values);

            Assert.Equal(expectedHash, key.GetHashCode());
        }

        [Fact]
        public void OverridesEqual()
        {
            Key first = new Key(1, "A", null);
            Key second = new Key(1, "A", null);

            Assert.Equal(first, second);
        }
    }
}
