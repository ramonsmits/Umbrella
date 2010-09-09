using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella.Containers;
using nVentive.Umbrella.Values;
using nVentive.Umbrella.Extensions;
using nVentive.Umbrella.Sources;
using nVentive.Umbrella.Messages;

namespace nVentive.Umbrella.Tests.Containers
{
    public class ContainerFixture
    {
        private Container container = new Container();

        [Fact]
        public void Disposable()
        {
            bool called = false;

            container.Disposable.Add(Actions.Create(() => called = true).ToDisposable());

            container.Dispose();

            Assert.True(called);
        }
    }
}
