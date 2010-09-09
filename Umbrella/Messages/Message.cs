using System;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Messages
{
    public class Message<TRequest, TResponse> : IMessage<TRequest, TResponse>
    {
        private readonly Func<TRequest, TResponse> message;

        public Message(Func<TRequest, TResponse> message)
        {
            this.message = message.Validation().NotNull("message");
        }

        public virtual Func<TRequest, TResponse> Func
        {
            get { return message; }
        }

        #region IMessage<TRequest,TResponse> Members

        public TResponse Send(TRequest request)
        {
            return message(request);
        }

        #endregion
    }
}