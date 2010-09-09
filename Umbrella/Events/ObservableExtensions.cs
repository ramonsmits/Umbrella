using System;
using nVentive.Umbrella.Events;
using nVentive.Umbrella.Messages;

namespace nVentive.Umbrella.Extensions
{
    public static class ObservableExtensions
    {
        public static IDisposable Observe(IObservable observable,
                                          IMessage<EventMessage<object, EventArgs>, Null> message)
        {
            //TODO Check is message is Message<,> and Message.Func.Target is IProxyable
            return observable.Observers.Subscribe(message);
        }

        public static IDisposable Observe(this IObservable observable, EventHandler<EventArgs> handler)
        {
            var messageHandler = handler.ToMessage();

            return Observe(observable, messageHandler);
        }

        public static void Raise(this IObservable observable, object sender)
        {
            Raise(observable, sender, EventArgs.Empty);
        }

        public static void Raise(this IObservable observable, object sender, EventArgs args)
        {
            observable.Observers.Send(new EventMessage<object, EventArgs>(sender, args));
        }

        //TODO Support Observer overloads.
        //public static IDisposable Observe(this IObservable observable, Func<Null, Null> func)
        //{
        //    return Extensions.Observe(observable, (sender, eventArgs) => func(null));
        //}
        //public static IDisposable Observe(this IObservable observable, Action action)
        //{
        //    return Extensions.Observe(observable, (sender, eventArgs) => action());
        //}
    }
}