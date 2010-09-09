using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella.Sources;
using System.Threading;

namespace nVentive.Umbrella.Tests.Sources
{
    public class ThreadLocalSourceFixture
    {
        [Fact]
        public void Get()
        {
            ISource<int> source = new ThreadLocalSource<int>(1);

            int actualValue = source.Value;

            Assert.Equal(1, actualValue);

            //TODO Use Parallel FX Extensions Instead.
            Thread thread = new Thread(() => actualValue = source.Value);
            thread.Start();
            thread.Join();

            Assert.Equal(0, actualValue);
        }
    }
}
