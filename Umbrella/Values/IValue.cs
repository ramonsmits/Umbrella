using nVentive.Umbrella.Messages;

namespace nVentive.Umbrella.Values
{
    public interface IValue<T>
    {
        IMessage<Null, T> Get { get; }
        IMessage<T, Null> Set { get; }
    }
}