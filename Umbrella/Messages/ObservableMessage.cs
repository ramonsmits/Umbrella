using System;
using System.Collections.Generic;
using nVentive.Umbrella.Decorator;
using nVentive.Umbrella.Events;

namespace nVentive.Umbrella.Messages
{
    //TODO Extract IObservableMessage<Null, T> ?
    public class ObservableMessage<T> : Decorator<IMessage<Null, T>>, IMessage<Null, T>, IObservable
    {
        private readonly IObservable observable;

        public ObservableMessage(IMessage<Null, T> target)
            : this(target, new Observable())
        {
        }

        public ObservableMessage(IMessage<Null, T> target, IObservable observable)
            : base(target)
        {
            this.observable = observable;
        }

        #region IMessage<Null,T> Members

        public T Send(Null request)
        {
            return Target.Send(request);
        }

        #endregion

        #region IObservable Members

        public ICollection<IMessage<EventMessage<object, EventArgs>, Null>> Observers
        {
            get { return observable.Observers; }
        }

        #endregion
    }
}