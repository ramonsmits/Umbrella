using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella.Sources;

namespace nVentive.Umbrella.Tests.Sources
{
    public class ReflectionSourceFixture
    {
        private Foo foo = new Foo(1);

        [Fact]
        public void Field()
        {
            ISource<string> source = new ReflectionSource<string>(foo, "S");

            Assert.Null(source.Value);

            source.Value = "A";

            Assert.Equal("A", source.Value);
        }

        [Fact]
        public void Property()
        {
            ISource<int> source = new ReflectionSource<int>(foo, "I");

            Assert.Equal(1, source.Value);

            source.Value = 2;

            Assert.Equal(2, source.Value);
        }

        [Fact]
        public void Method()
        {
            ISource<int> source = new ReflectionSource<int>(foo, "GetI", "SetI");

            Assert.Equal(1, source.Value);

            source.Value = 2;

            Assert.Equal(2, source.Value);
        }

        public class Foo
        {
            public Foo(int i)
            {
                I = i;
            }

            public int I
            {
                get;
                set;
            }

            public string S;

            public int GetI()
            {
                return I;
            }

            public void SetI(int i)
            {
                I = i;
            }
        }
    }
}
