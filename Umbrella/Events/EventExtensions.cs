using System;
using System.ComponentModel;
using System.Linq.Expressions;
using nVentive.Umbrella.Events;
using nVentive.Umbrella.Messages;

namespace nVentive.Umbrella.Extensions
{
    public static class EventExtensions
    {
        public static void Raise(this EventHandler handler)
        {
            Raise(handler, null, EventArgs.Empty);
        }

        public static void Raise(this EventHandler handler, object sender, EventArgs args)
        {
            if (handler != null)
            {
                handler(sender, args);
            }
        }

        public static void Raise<TEventArgs>(this EventHandler<TEventArgs> handler)
            where TEventArgs : EventArgs
        {
            Raise(handler, null, null);
        }

        public static void Raise<TEventArgs>(this EventHandler<TEventArgs> handler, object sender, TEventArgs args)
            where TEventArgs : EventArgs
        {
            if (handler != null)
            {
                handler(sender, args);
            }
        }

        public static IMessage<EventMessage<object, TEventArgs>, Null> ToMessage<TEventArgs>(
            this EventHandler<TEventArgs> handler)
            where TEventArgs : EventArgs
        {
            return
                Actions.Create<EventMessage<object, TEventArgs>>(item => Raise(handler, item.Sender, item.Args)).
                    ToMessage();
        }

        public static IDisposable Observe(this INotifyPropertyChanged notify, PropertyChangedEventHandler handler)
        {
            notify.PropertyChanged += handler;

            return Actions.Create(() => notify.PropertyChanged -= handler).ToDisposable();
        }

        public static void Notify<T, TValue>(
            this T instance,
            PropertyChangedEventHandler handler,
            Expression<Func<T, TValue>> selector)
            where T : INotifyPropertyChanged
        {
            Notify<T, TValue>(instance, handler, selector, default(TValue), default(TValue));
        }

        public static void Notify<T, TValue>(
            this T instance,
            PropertyChangedEventHandler handler,
            Expression<Func<T, TValue>> selector,
            TValue oldValue,
            TValue newValue)
            where T : INotifyPropertyChanged
        {
            if (handler == null) return;
            
            var memberExpression = selector.Body as MemberExpression;

            if (memberExpression != null)
            {
                handler(instance, new ExtendedPropertyChangedEventArgs<TValue>(memberExpression.Member.Name, oldValue, newValue));
            }
        }
    }
}