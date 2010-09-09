using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xunit;
using nVentive.Umbrella.Values;
using nVentive.Umbrella.Extensions;
using nVentive.Umbrella.Events;

namespace nVentive.Umbrella.Tests.Values
{
    public class ValueFixture
    {
        [Fact]
        public void Get()
        {
            IValue<int> value = new Value<int>(1);

            Assert.Equal(1, value.Get.Send());
        }

        [Fact]
        public void Set()
        {
            IValue<int> value = new Value<int>(1);

            value.Set(2);

            Assert.Equal(2, value.Get.Send());
        }

        [Fact]
        public void Observable()
        {
            IValue<int> value = new Value<int>();

            Assert.True(value.Get is IObservable);

            bool changed = false;

            object sender = null;
            EventArgs args = null;

            value.Observe((s, a) => { changed = true; sender = s; args = a; });

            value.Set(1);

            Assert.True(changed);
            Assert.Same(sender, value);
            Assert.Same(EventArgs.Empty, args);
        }

        [Fact]
        public void Binding()
        {
            IValue<int> textBox = new Value<int>();
            IValue<int> personAge = new Value<int>();

            IDisposable binding = textBox.Bind(personAge);

            textBox.Set(30);
            Assert.Equal(30, personAge.Get());

            personAge.Set(20);
            Assert.Equal(20, textBox.Get());

            binding.Dispose();

            personAge.Set(10);
            Assert.Equal(20, textBox.Get());
        }

        protected virtual Action<T> AssertEx<T>(T instance)
        {
            return null;
        }
    }
}
