using nVentive.Umbrella.Composite;
using nVentive.Umbrella.Messages;

namespace nVentive.Umbrella.Conditions
{
    public interface ICompositeCondition : IComposite<IMessage<Null, bool>>, IMessage<Null, bool>
    {
    }
}