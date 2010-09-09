using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella.Sources;

namespace nVentive.Umbrella.Tests.Sources
{
    public class CompositeSourceFixture
    {
        [Fact]
        public void Composite()
        {
            ISource<string> first = new Source<string>();
            ISource<string> second = new Source<string>();
            ISource<string> third = new Source<string>();

            ISource<string> composite = new CompositeSource<string>(first, second, third);

            Assert.Null(composite.Value);

            third.Value = "C";

            Assert.Equal("C", composite.Value);

            second.Value = "B";

            Assert.Equal("B", composite.Value);

            first.Value = "A";

            Assert.Equal("A", composite.Value);
        }
    }
}
