namespace nVentive.Umbrella.Messages
{
    public interface IMessage<TRequest, TResponse>
    {
        TResponse Send(TRequest request);
    }
}