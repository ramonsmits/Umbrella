using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Tests.Collections
{
    public class ListExtensionsFixture
    {
        private IList<int> list = new List<int> { 1, 2, 3};

        [Fact]
        public void AsReadOnly()
        {

            Assert.True(list.AsReadOnly().IsReadOnly);
        }

        [Fact]
        public void Adapt()
        {
            IList<string> adapter = list.Adapt<int, string>();

            Assert.NotNull(adapter);
        }
    }
}
