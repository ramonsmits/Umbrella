using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using nVentive.Umbrella.Messages;

namespace nVentive.Umbrella.Conditions
{
    public interface IConditionExtensions
    {
        IMessage<Null, bool> Not(IMessage<Null, bool> message);
        IMessage<Null, bool> And(IMessage<Null, bool> x, IMessage<Null, bool> y);
        IMessage<Null, bool> Or(IMessage<Null, bool> x, IMessage<Null, bool> y);
    }
}
