using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace nVentive.Umbrella.Tests
{
    public class FuncsFixture
    {
        [Fact]
        public void Default()
        {
            Assert.Equal(0, Funcs<int>.Default());
        }

        [Fact]
        public void CreateInstance()
        {
            Assert.NotNull(Funcs<Foo>.CreateInstance());
        }

        [Fact]
        public void CastTo()
        {
            Assert.Equal(1, Funcs<int>.CastTo(1));
        }

        [Fact]
        public void CastFrom()
        {
            Assert.Equal(1, Funcs<int>.CastFrom(1));
        }

        [Fact]
        public void Cast()
        {
            Assert.NotNull(Funcs<Foo, DerivedFoo>.Cast(new DerivedFoo()));
        }

        [Fact]
        public void Convert()
        {
            Assert.Equal(1, Funcs<string, int>.Convert("1"));
        }

        [Fact]
        public void CreateInstance_Two()
        {
            Assert.IsType(typeof(DerivedFoo), Funcs<Foo, DerivedFoo>.CreateInstance());
        }

        [Fact]
        public void ToNullable()
        {
            Assert.Equal(1, NullableFuncs<int>.ToNullable(1));
        }

        [Fact]
        public void FromNullable()
        {
            Assert.Equal(0, NullableFuncs<int>.FromNullable(null));
        }

        public class Foo
        {
        }

        public class DerivedFoo : Foo
        {
        }
    }
}
