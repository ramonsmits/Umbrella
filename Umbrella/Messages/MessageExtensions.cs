using System;
using System.Collections.Generic;
using nVentive.Umbrella.Messages;

namespace nVentive.Umbrella.Extensions
{
    public static class MessageExtensions
    {
        public static IMessage<Null, T> ToMessage<T>(this Func<T> message)
        {
            return new Message<Null, T>(message.ToFunc());
        }

        public static IMessage<TRequest, TResponse> ToMessage<TRequest, TResponse>(
            this Func<TRequest, TResponse> message)
        {
            return new Message<TRequest, TResponse>(message);
        }

        public static IMessage<Null, Null> ToMessage(this Action message)
        {
            return new Message<Null, Null>(message.ToFunc());
        }

        public static IMessage<T, Null> ToMessage<T>(this Action<T> message)
        {
            return new Message<T, Null>(message.ToFunc());
        }

        public static IMessage<Null, T> ToObservable<T>(this IMessage<Null, T> message)
        {
            return new ObservableMessage<T>(message);
        }

        public static Func<TRequest, TResponse> ToFunc<TRequest, TResponse>(this IMessage<TRequest, TResponse> message)
        {
            var realMessage = message as Message<TRequest, TResponse>;

            return realMessage == null ? message.Send : realMessage.Func;
        }

        public static Action<T> ToAction<T>(IMessage<T, Null> message)
        {
            return request => message.Send(request);
        }

        public static IMessage<TRequest, TResponse> Chain<TRequest, TTemp, TResponse>(
            this IMessage<TRequest, TTemp> first, IMessage<TTemp, TResponse> second)
        {
            return new MessageChain<TRequest, TTemp, TResponse>(first, second);
        }

        public static IMessage<Null, Null> Bind<T>(this IMessage<Null, T> get, IMessage<T, Null> set)
        {
            return new MessageBinding<T>(get, set);
        }

        public static T Send<T>(this IMessage<Null, T> message)
        {
            return message.Send(null);
        }

        public static IEnumerable<TResponse> Send<TRequest, TResponse>(
            this IEnumerable<IMessage<TRequest, TResponse>> items, TRequest request)
        {
            var responses = new List<TResponse>();

            foreach (var item in items)
            {
                //yield return item.Send(request);
                responses.Add(item.Send(request));
            }

            return responses;
            //TODO If using items.Select or yield return, it never gets into this method from ValueFixture.
            //return items.Select(item => item.Send(request));
        }

        public static IDisposable ToDisposable(this IMessage<Null, Null> message)
        {
            var disposable = message as IDisposable;

            return disposable ?? new DisposableMessage(message);
        }

        public static IMessage<TRequest, TResponse> Intercept<TRequest, TResponse>(
            this IMessage<TRequest, TResponse> message, IMessage<TRequest, TRequest> before,
            IMessage<TResponse, TResponse> after)
        {
            if (before != null)
            {
                message = Chain(before, message);
            }

            if (after != null)
            {
                message = Chain(message, after);
            }

            return message;
        }

        public static IDisposable ToDisposable(this Action action)
        {
            return action.ToMessage().ToDisposable();
        }

        public static IMessage<TRequest, TResponse> Intercept<TRequest, TResponse>(
            this IMessage<TRequest, TResponse> message, Action<TRequest> before, Action<TResponse> after)
        {
            return Intercept(message, before.ToInterceptor().ToMessage(), after.ToInterceptor().ToMessage());
        }
    }
}