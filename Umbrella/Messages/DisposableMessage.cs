using System;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Messages
{
    public class DisposableMessage : IDisposable
    {
        private readonly IMessage<Null, Null> message;

        public DisposableMessage(IMessage<Null, Null> message)
        {
            this.message = message.Validation().NotNull("message");
        }

        #region IDisposable Members

        public void Dispose()
        {
            message.Send();
        }

        #endregion
    }
}