using System.Linq;
using nVentive.Umbrella.Messages;

namespace nVentive.Umbrella.Conditions
{
    public class AndCondition : CompositeCondition
    {
        public AndCondition(params IMessage<Null, bool>[] items)
            : base(items)
        {
        }

        public override bool Send(Null request)
        {
            return Items.All(MessageFunc<bool>.Response);
        }
    }
}