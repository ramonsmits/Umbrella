using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nVentive.Umbrella.Messages
{
    public interface IMessageExtensions
    {
        IMessage<Null, T> ToMessage<T>(Func<T> message);
        IMessage<TRequest, TResponse> ToMessage<TRequest, TResponse>(Func<TRequest, TResponse> message);
        IMessage<Null, Null> ToMessage(Action message);
        IMessage<T, Null> ToMessage<T>(Action<T> message);
        IMessage<Null, T> ToObservable<T>(IMessage<Null, T> message);

        Func<TRequest, TResponse> ToFunc<TRequest, TResponse>(IMessage<TRequest, TResponse> message);
        Action<T> ToAction<T>(IMessage<T, Null> message);

        IMessage<TRequest, TResponse> Chain<TRequest, TTemp, TResponse>(IMessage<TRequest, TTemp> first, IMessage<TTemp, TResponse> second);

        IMessage<Null, Null> Bind<T>(IMessage<Null, T> get, IMessage<T, Null> set);

        T Send<T>(IMessage<Null, T> message);
        IEnumerable<TResponse> Send<TRequest, TResponse>(IEnumerable<IMessage<TRequest, TResponse>> items, TRequest request);

        IDisposable Using(IMessage<Null, Null> message);

        IMessage<TRequest, TResponse> Intercept<TRequest, TResponse>(IMessage<TRequest, TResponse> message, IMessage<TRequest, TRequest> before, IMessage<TResponse, TResponse> after);
    }
}
