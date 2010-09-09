using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nVentive.Umbrella.Values;
using Xunit;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Tests.Values
{
    public class ValueBindingFixture
    {
        private IValue<int> left = new Value<int>();
        private IValue<int> right = new Value<int>();

        [Fact]
        public void Binding()
        {
            IDisposable binding = new ValueBinding<int>(left, right);

            left.Set(1);

            Assert.Equal(1, right.Get());

            right.Set(2);

            Assert.Equal(2, left.Get());

            binding.Dispose();

            left.Set(3);

            Assert.Equal(2, right.Get());
        }
    }
}
