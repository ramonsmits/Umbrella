using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella.Sources;

namespace nVentive.Umbrella.Tests.Sources
{
    public class SourceAdapterFixture
    {
        private ISource<string> adaptee = new Source<string>("1");

        private ISource<int> adapter;

        public SourceAdapterFixture()
        {
            adapter = new SourceAdapter<string, int>(adaptee);
        }

        [Fact]
        public void Get()
        {
            Assert.Equal(1, adapter.Value);
        }

        [Fact]
        public void Set()
        {
            adapter.Value = 2;

            Assert.Equal("2", adaptee.Value);
        }
    }
}
