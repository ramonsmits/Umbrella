using System;
using nVentive.Umbrella.Events;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella
{
    public static class Actions
    {
        public static readonly Action Null = () => { };

        public static readonly Action<object, IObservable> Raise = (sender, publisher) => publisher.Raise(sender);

        public static Action Create(Action action)
        {
            return action;
        }

        public static Action<T> Create<T>(Action<T> action)
        {
            return action;
        }
    }
}