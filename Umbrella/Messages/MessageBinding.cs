using System;
using nVentive.Umbrella.Events;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Messages
{
    public class MessageBinding<T> : MessageChain<Null, T, Null>, IDisposable
    {
        private readonly IDisposable subscription;

        public MessageBinding(IMessage<Null, T> get, IMessage<T, Null> set)
            : base(get, set)
        {
            var observable = get as IObservable;

            if (observable != null)
            {
                subscription = observable.Observe((sender, args) => Send(null));
            }
        }

        #region IDisposable Members

        public virtual void Dispose()
        {
            if (subscription != null)
            {
                subscription.Dispose();
            }
        }

        #endregion
    }
}