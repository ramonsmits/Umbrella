using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using nVentive.Umbrella;
using nVentive.Umbrella.Messages;
using nVentive.Umbrella.Extensions;

namespace nVentive.Framework.Tests.Conditions
{
    public class AndConditionFixture
    {
        [Fact]
        public void True()
        {
            IMessage<Null, bool> lhs = new Message<Null, bool>(notUsed => true);
            IMessage<Null, bool> rhs = new Message<Null, bool>(notUsed => true);

            var andMessage = lhs.And(rhs);

            Assert.True(andMessage.Send());
        }

        [Fact]
        public void False()
        {
            IMessage<Null, bool> lhs = new Message<Null, bool>(notUsed => true);
            IMessage<Null, bool> rhs = new Message<Null, bool>(notUsed => false);

            var andMessage = lhs.And(rhs);

            Assert.False(andMessage.Send());
        }
    }
}
