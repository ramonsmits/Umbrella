using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella.Containers;
using nVentive.Umbrella.Extensions;
using nVentive.Umbrella.Values;
using nVentive.Umbrella.Sources;

namespace nVentive.Umbrella.Tests.Containers
{
    public class ContainerExtensionsFixture
    {
        private Container container = new Container();

        [Fact]
        public void GetSource()
        {
            ISource<int> value = container.GetSource<int>("I");

            Assert.NotNull(value);
            Assert.Same(value, container.GetSource<int>("I"));
        }

        [Fact]
        public void GetSource_Factory()
        {
            bool calledFirst = false;
            bool calledSecond = false;

            ISource<int> firstValue = container.GetSource<int>("I", () => { calledFirst = true; return 1; });
            ISource<int> secondValue = container.GetSource<int>("I", () => { calledSecond = true; return 1; });

            // Value not yet fetched, so factory hasn't been called.
            Assert.False(calledFirst);
            Assert.False(calledSecond);

            Assert.Equal(1, firstValue.Value);
            Assert.True(calledFirst);
            Assert.False(calledSecond);
            Assert.Same(firstValue, secondValue);
        }

        [Fact]
        public void GetSource_SourceFactory()
        {
            bool calledFirst = false;
            bool calledSecond = false;

            ISource<int> firstValue = container.GetSource<int>("I", () => { calledFirst = true; return new Source<int>(1); });
            ISource<int> secondValue = container.GetSource<int>("I", () => { calledFirst = true; return new Source<int>(1); });

            Assert.Equal(1, firstValue.Value);
            Assert.True(calledFirst);
            Assert.False(calledSecond);
            Assert.Same(firstValue, secondValue);
        }

        [Fact]
        public void GetValue()
        {
            IValue<int> value = container.GetValue<int>("I");

            Assert.NotNull(value);
            Assert.Same(value, container.GetValue<int>("I"));
        }

        [Fact]
        public void GetValue_Factory()
        {
            bool calledFirst = false;
            bool calledSecond = false;

            IValue<int> firstValue = container.GetValue<int>("I", () => {calledFirst = true; return 1;});
            IValue<int> secondValue = container.GetValue<int>("I", () => {calledSecond = true; return 1;});

            // Value not yet fetched, so factory hasn't been called.
            Assert.False(calledFirst);
            Assert.False(calledSecond);

            Assert.Equal(1, firstValue.Get());
            Assert.True(calledFirst);
            Assert.False(calledSecond);
            Assert.Same(firstValue, secondValue);
        }

        [Fact]
        public void GetValue_ValueFactory()
        {
            bool calledFirst = false;
            bool calledSecond = false;

            IValue<int> firstValue = container.GetValue<int>("I", () => { calledFirst = true; return new Value<int>(1); });
            IValue<int> secondValue = container.GetValue<int>("I", () => { calledFirst = true; return new Value<int>(1); });

            Assert.Equal(1, firstValue.Get());
            Assert.True(calledFirst);
            Assert.False(calledSecond);
            Assert.Same(firstValue, secondValue);
        }

        [Fact]
        public void Sources()
        {
            Foo foo = new Foo();

            foo.Source = 1;
            Assert.Equal(1, foo.Source);
        }

        [Fact]
        public void Values()
        {
            Foo foo = new Foo();

            foo.Value = 3;
            Assert.Equal(3, foo.Value);
        }

        private class Foo : Container
        {
            public int Source
            {
                get { return Sources.Get<int>("Source"); }
                set { Sources.Set("Source", value); }
            }

            public int Value
            {
                get { return Values.Get<int>("Value"); }
                set { Values.Set("Value", value); }
            }
        }
    }
}
