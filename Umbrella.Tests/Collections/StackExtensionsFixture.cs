using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Tests.Collections
{
    public class StackExtensionsFixture
    {
        private Stack<int> stack = new Stack<int>();

        [Fact]
        public void PeekOrDefault()
        {
            Assert.Equal(0, stack.PeekOrDefault());
        }

        [Fact]
        public void Subscribe()
        {
            IDisposable subscription = stack.Subscribe(1);

            Assert.Equal(1, stack.Peek());

            subscription.Dispose();

            Assert.Empty(stack);
        }
    }
}
