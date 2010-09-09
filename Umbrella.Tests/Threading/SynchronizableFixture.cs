using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella.Threading;

namespace nVentive.Framework.Tests.Threading
{
    public class SynchronizableFixture
    {
        [Fact]
        public void Lock()
        {
            object instance = new object();

            var synchronizable = new Synchronizable<object>(instance);

            Assert.NotNull(synchronizable.Lock);
        }
    }
}
