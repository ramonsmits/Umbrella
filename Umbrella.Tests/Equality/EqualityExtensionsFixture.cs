using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella.Extensions;
using System.Collections;

namespace nVentive.Umbrella.Tests.Equality
{
    public class EqualityExtensionsFixture
    {
        [Fact]
        public void Equality()
        {
            Foo foo = new Foo();

            Assert.Same(foo, foo.Equality().ExtendedValue);
        }

        [Fact]
        public void CalculateGetHashCode()
        {
            Foo foo = new Foo();

            int expectedHashCode = 
                EqualityExtensions.Equality<Foo>(foo).GetHashCode(new object[] { foo.I, foo.S, foo.Bar });
            
            Assert.Equal(expectedHashCode, foo.GetHashCode());
        }

        [Fact]
        public void Equal()
        {
            Foo foo = new Foo();
            Foo similarFoo = new Foo();
            
            Foo differentFoo = new Foo();
            differentFoo.Bar.S = "Bar";

            Assert.Equal(similarFoo, foo);
            Assert.NotEqual(differentFoo, foo);
        }

        [Fact]
        public void Equal_EnumerableSwap()
        {
            OtherFoo foo = new OtherFoo() { I1 = 42, I2 = 24 };
	    OtherFoo foo2 = new OtherFoo() { I1 = 24, I2 = 42 };

	    Assert.NotEqual(foo.GetHashCode(), foo2.GetHashCode());
        }

        [Fact]
        public void Equal_Enumerable()
        {
            List<int> items = new List<int> { 1, 2, 3 };
            List<int> similarItems = new List<int> { 1, 2, 3 };
            List<int> differentItems = new List<int> { 4, 5, 6 };
            List<int> longerItems = new List<int> { 1, 2, 3, 4 };
            List<int> shorterItems = new List<int> { 1, 2 };

            Assert.NotEqual(similarItems, items);
            Assert.True(items.Equality().Equal(similarItems));
            Assert.False(items.Equality().Equal(differentItems));
            Assert.False(items.Equality().Equal(longerItems));
            Assert.False(items.Equality().Equal(shorterItems));
        }

        private class Foo
        {
            private static readonly Func<Foo, IEnumerable<object>> Fields = item => new object[] { item.I, item.S, item.Bar };

            public int I = 1;
            public string S;
            public Bar Bar = new Bar();

            public override int GetHashCode()
            {
                return this.Equality().GetHashCode(Fields);
            }

            public override bool Equals(object obj)
            {
                return this.Equality().Equal<Foo>(obj, Fields);
            }
        }

        public class Bar
        {
            public int I = 1;
            public string S;

            public override bool Equals(object obj)
            {
                Bar other = obj as Bar;

                if (other == null)
                {
                    return false;
                }

                return Equals(I, other.I) &&
                    Equals(S, other.S);
            }

            public override int GetHashCode()
            {
                return this.Equality().GetHashCode(new object[] { I, S });
            }
        }

        public class OtherFoo
        {
            private static readonly Func<OtherFoo, IEnumerable<object>> Fields = item => new object[] { item.I1, item.I2 };

            public int I1 = 42;
            public int I2 = 24;

            public override int GetHashCode()
            {
                return this.Equality().GetHashCode(Fields);
            }

            public override bool Equals(object obj)
            {
	        return this.Equality().Equal<OtherFoo>(obj, Fields);
            }
        }
    }
}
