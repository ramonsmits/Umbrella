using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella.Sources;

namespace nVentive.Umbrella.Tests.Sources
{
    public class WeakSourceFixture
    {
        [Fact]
        public void Get()
        {
            Foo foo = new Foo();

            ISource<Foo> source = new WeakSource<Foo>(foo);

            Assert.Same(foo, source.Value);
        }

        [Fact]
        public void Set()
        {
            ISource<Foo> source = new WeakSource<Foo>();

            Foo foo = new Foo();

            source.Value = foo;

            Assert.Same(foo, source.Value);
        }

        [Fact]
        public void GarbageCollect()
        {
            Foo foo = new Foo();

            ISource<Foo> source = new WeakSource<Foo>(foo);

            GC.Collect();
            GC.WaitForPendingFinalizers();

            Assert.Same(foo, source.Value);

            foo = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();

            Assert.Null(source.Value);
        }

        public class Foo
        {
        }
    }
}
