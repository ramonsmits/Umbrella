using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Tests.Extensions
{
    public class ObjectExtensionsFixture
    {
        [Fact]
        public void Extensions()
        {
            string s = "A";

            Assert.Equal(s, s.Extensions().ExtendedValue);
        }

        [Fact]
        public void IsDefault()
        {
            Assert.True(0.Extensions().IsDefault());
            Assert.False(1.Extensions().IsDefault());

            Assert.True(((string)null).Extensions().IsDefault());
            Assert.False("A".Extensions().IsDefault());
        }

        [Fact]
        public void Dispose_Disposable()
        {
            bool called = false;

            object disposable = Actions.Create(() => called = true).ToDisposable();

            disposable.Extensions().Dispose();

            Assert.True(called);
        }

        [Fact]
        public void Dispose_NonDisposable()
        {
            new object().Extensions().Dispose();
        }

        [Fact]
        public void Using_Disposable()
        {
            object disposable = Actions.Create(() => { }).ToDisposable();

            Assert.Same(disposable, disposable.Extensions().Using());
        }

        [Fact]
        public void Using_NonDisposable()
        {
            Assert.Same(NullDisposable.Instance, new object().Extensions().Using());
        }

        [Fact]
        public void Maybe_Action_No_Parameters()
        {
            int count = 0;
            var disposable = Actions.Create(() => { count++; }).ToDisposable();

            disposable.Maybe(() => disposable.Dispose());
            Assert.Equal(count, 1);

            disposable = null;
            disposable.Maybe(() => disposable.Dispose());
            Assert.Equal(count, 1);
        }

        [Fact]
        public void Maybe_Action()
        {
            int count = 0;
            var disposable = Actions.Create(() => { count++; }).ToDisposable();

            disposable.Maybe(d => d.Dispose());
            Assert.Equal(count, 1);

            disposable = null;
            disposable.Maybe(d => d.Dispose());
            Assert.Equal(count, 1);
        }

        [Fact]
        public void Maybe_FuncImplicitDefaultNullablePrimitive()
        {
            int? value = null;
            Assert.Null(value.Maybe(t => t + 1));

            value = 41;
            Assert.Equal(value.Maybe(t => t + 1), 42);
        }

        [Fact]
        public void Maybe_FuncExplicitDefault()
        {
            int? value = null;
            Assert.Equal(value.Maybe(t => t + 1, 42), 42);

            value = 41;
            Assert.Equal(value.Maybe(t => t + 1, 21), 42);
        }
    }
}
