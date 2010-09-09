using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella.Sources;

namespace nVentive.Umbrella.Tests.Sources
{
    public class DisposableSourceFixture
    {
        private ISource<string> source;
        private ISource<string> disposableSource;

        public DisposableSourceFixture()
        {
            source = new Source<string>("A");
        }

        [Fact]
        public void Value()
        {
            IDisposableSource<string> disposableSource = new DisposableSource<string>(source);

            Assert.Equal("A", disposableSource.Value);
        }

        [Fact]
        public void Dispose_ResetsValueToDefault()
        {
            IDisposableSource<string> disposableSource = new DisposableSource<string>(source);

            disposableSource.Dispose();

            Assert.Null(source.Value);
        }

        [Fact]
        public void Dispose_CallsAction()
        {
            bool called = false;

            IDisposableSource<string> disposableSource = new DisposableSource<string>(source, () => called = true);

            Assert.False(called);

            disposableSource.Dispose();

            Assert.True(called);
        }
    }
}
