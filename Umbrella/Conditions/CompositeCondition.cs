using System;
using System.Collections.Generic;
using nVentive.Umbrella.Composite;
using nVentive.Umbrella.Events;
using nVentive.Umbrella.Extensions;
using nVentive.Umbrella.Messages;

namespace nVentive.Umbrella.Conditions
{
    public abstract class CompositeCondition : Composite<IMessage<Null, bool>>,
                                               ICompositeCondition, IObservable
    {
        private readonly Observable observable = new Observable();

        private readonly Dictionary<IMessage<Null, bool>, IDisposable> subscriptions =
            new Dictionary<IMessage<Null, bool>, IDisposable>();

        // TODO convert to protected?
        public CompositeCondition(params IMessage<Null, bool>[] items)
            : base(items)
        {
        }

        public override IMessage<Null, bool> this[int index]
        {
            get { return base[index]; }
            set
            {
                Unsubsribe(this[index]);

                base[index] = value;

                Subscribe(value);
            }
        }

        #region IMessage<Null,bool> Members

        public abstract bool Send(Null request);

        #endregion

        #region IObservable Members

        public ICollection<IMessage<EventMessage<object, EventArgs>, Null>> Observers
        {
            get { return observable.Observers; }
        }

        #endregion

        public override void Add(IMessage<Null, bool> item)
        {
            base.Add(item);

            Subscribe(item);
        }

        public override bool Remove(IMessage<Null, bool> item)
        {
            var found = base.Remove(item);

            Unsubsribe(item);

            return found;
        }

        public override void Clear()
        {
            Items.ForEach(Unsubsribe);

            base.Clear();
        }

        protected virtual void Subscribe(IMessage<Null, bool> item)
        {
            var iobservable = item as IObservable;

            if (iobservable == null) return;

            var subscription = iobservable.Observe(OnChanged);

            subscriptions.Add(item, subscription);
        }

        protected virtual void Unsubsribe(IMessage<Null, bool> item)
        {
            IDisposable subscription;

            if (!subscriptions.TryGetValue(item, out subscription)) return;

            subscriptions.Remove(item);

            subscription.Dispose();
        }

        protected virtual void OnChanged(object sender, EventArgs args)
        {
            observable.Raise(this, args);
        }
    }
}