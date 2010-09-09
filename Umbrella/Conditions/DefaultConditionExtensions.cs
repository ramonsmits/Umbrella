using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using nVentive.Umbrella.Messages;

namespace nVentive.Umbrella.Conditions
{
    public class DefaultConditionExtensions : IConditionExtensions
    {
        #region IConditionExtensions Members

        public IMessage<Null, bool> Not(IMessage<Null, bool> message)
        {
            return new NotCondition(message);
        }

        public IMessage<Null, bool> And(IMessage<Null, bool> x, IMessage<Null, bool> y)
        {
            return new AndCondition(x, y);
        }

        public IMessage<Null, bool> Or(IMessage<Null, bool> x, IMessage<Null, bool> y)
        {
            return new OrCondition(x, y);
        }

        #endregion
    }
}
