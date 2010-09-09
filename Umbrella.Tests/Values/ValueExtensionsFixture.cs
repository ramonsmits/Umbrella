using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella.Extensions;
using nVentive.Umbrella.Values;
using nVentive.Umbrella.Sources;

namespace nVentive.Umbrella.Tests.Values
{
    public class ValueExtensionsFixture
    {
        [Fact]
        public void Get()
        {
            IValue<int> value = new Value<int>(1);

            Assert.Equal(1, value.Get());
        }

        [Fact]
        public void Set()
        {
            IValue<int> value = new Value<int>();

            value.Set(1);

            Assert.Equal(1, value.Get());
        }

        [Fact]
        public void Bind()
        {
            Assert.NotNull(new Value<int>().Bind(new Value<int>()));
        }

        [Fact]
        public void ToValue()
        {
            ISource<int> source = new Source<int>(1);

            IValue<int> value = source.ToValue();

            Assert.Equal(1, value.Get());

            value.Set(2);

            Assert.Equal(2, source.Value);
        }

        [Fact]
        public void ToSource()
        {
            IValue<int> value = new Value<int>(1);

            ISource<int> source = value.ToSource();

            Assert.Equal(1, source.Value);

            source.Value = 2;

            Assert.Equal(2, value.Get());
        }

        [Fact]
        public void Observe()
        {
            IValue<int> value = new Value<int>();

            value.Observe((s, a) => { });
        }
    }
}
