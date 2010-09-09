using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Messages
{
    public class MessageChain<TRequest, TTemp, TResponse> : IMessage<TRequest, TResponse>
    {
        private readonly IMessage<TRequest, TTemp> first;
        private readonly IMessage<TTemp, TResponse> second;

        public MessageChain(IMessage<TRequest, TTemp> first, IMessage<TTemp, TResponse> second)
        {
            this.first = first.Validation().NotNull("first");
            this.second = second.Validation().NotNull("second");
        }

        protected virtual IMessage<TRequest, TTemp> First
        {
            get { return first; }
        }

        protected virtual IMessage<TTemp, TResponse> Second
        {
            get { return second; }
        }

        #region IMessage<TRequest,TResponse> Members

        public virtual TResponse Send(TRequest request)
        {
            var temp = First.Send(request);

            return Second.Send(temp);
        }

        #endregion
    }
}