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
    public class NotConditionFixture
    {
        [Fact]
        public void Not()
        {
            IMessage<Null, bool> message = new Message<Null, bool>(notUsed => true);

            var notMessage = message.Not();

            Assert.False(notMessage.Send());
        }
    }
}
