using System.Linq;
using nVentive.Umbrella.Messages;

namespace nVentive.Umbrella.Conditions
{
    public class OrCondition : CompositeCondition
    {
        public OrCondition(params IMessage<Null, bool>[] items)
            : base(items)
        {
        }

        public override bool Send(Null request)
        {
            return Items.Any(MessageFunc<bool>.Response);
        }
    }
}