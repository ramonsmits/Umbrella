using System;
using System.Collections.Generic;
using nVentive.Umbrella.Decorator;
using nVentive.Umbrella.Events;
using nVentive.Umbrella.Extensions;
using nVentive.Umbrella.Messages;

namespace nVentive.Umbrella.Conditions
{
    public class NotCondition : Decorator<IMessage<Null, bool>>, IMessage<Null, bool>, IObservable
    {
        private readonly Observable observable = new Observable();
        private IDisposable subscription; // TODO assigned but not used
        
        public NotCondition(IMessage<Null, bool> target)
            : base(target)
        {
            var observableTarget = target as IObservable;

            if (observableTarget != null)
            {
                subscription = observableTarget.Observe(OnChanged);
            }
        }

        #region IMessage<Null,bool> Members

        public virtual bool Send(Null request)
        {
            return !Target.Send();
        }

        #endregion

        #region IObservable Members

        public ICollection<IMessage<EventMessage<object, EventArgs>, Null>> Observers
        {
            get { return observable.Observers; }
        }

        #endregion

        protected virtual void OnChanged(object sender, EventArgs args)
        {
            observable.Raise(this, args);
        }
    }
}