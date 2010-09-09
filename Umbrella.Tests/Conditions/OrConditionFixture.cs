using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella.Messages;
using nVentive.Umbrella.Extensions;
using nVentive.Umbrella;

namespace nVentive.Framework.Tests.Conditions
{
    public class OrConditionFixture
    {
        [Fact]
        public void True()
        {
            IMessage<Null, bool> lhs = new Message<Null, bool>(notUsed => true);
            IMessage<Null, bool> rhs = new Message<Null, bool>(notUsed => false);

            var orMessage = lhs.Or(rhs);

            Assert.True(orMessage.Send());
        }

        [Fact]
        public void False()
        {
            IMessage<Null, bool> lhs = new Message<Null, bool>(notUsed => false);
            IMessage<Null, bool> rhs = new Message<Null, bool>(notUsed => false);

            var orMessage = lhs.Or(rhs);

            Assert.False(orMessage.Send());
        }
    }
}
