using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Messages
{
    public class DefaultMessageExtensions : IMessageExtensions
    {
        #region IMessageExtensions Members

        public virtual IMessage<Null, T> ToMessage<T>(Func<T> message)
        {
        }

        public virtual IMessage<TRequest, TResponse> ToMessage<TRequest, TResponse>(Func<TRequest, TResponse> message)
        {
        }

        public virtual IMessage<Null, Null> ToMessage(Action message)
        {
        }

        public virtual IMessage<T, Null> ToMessage<T>(Action<T> message)
        {
        }

        public virtual IMessage<Null, T> ToObservable<T>(IMessage<Null, T> message)
        {
        }

        public virtual Func<TRequest, TResponse> ToFunc<TRequest, TResponse>(IMessage<TRequest, TResponse> message)
        {
        }

        public virtual Action<T> ToAction<T>(IMessage<T, Null> message)
        {
        }

        public virtual IMessage<TRequest, TResponse> Chain<TRequest, TTemp, TResponse>(IMessage<TRequest, TTemp> first, IMessage<TTemp, TResponse> second)
        {
        }

        public virtual IMessage<Null, Null> Bind<T>(IMessage<Null, T> get, IMessage<T, Null> set)
        {
        }

        public virtual IDisposable Using(IMessage<Null, Null> message)
        {
        }

        public virtual T Send<T>(IMessage<Null, T> message)
        {
        }

        public virtual IEnumerable<TResponse> Send<TRequest, TResponse>(IEnumerable<IMessage<TRequest, TResponse>> items, TRequest request)
        {
        }

        public virtual IMessage<TRequest, TResponse> Intercept<TRequest, TResponse>(
            IMessage<TRequest, TResponse> message,
            IMessage<TRequest, TRequest> before,
            IMessage<TResponse, TResponse> after)
        {
        }

        #endregion
    }
}
