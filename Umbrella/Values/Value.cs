using System;
using nVentive.Umbrella.Containers;
using nVentive.Umbrella.Events;
using nVentive.Umbrella.Extensions;
using nVentive.Umbrella.Messages;
using nVentive.Umbrella.Sources;

namespace nVentive.Umbrella.Values
{
    public class Value<T> : Container, IValue<T>
    {
        private readonly Func<T, T, bool> comparer;
        private readonly Action<object, IObservable> eventRaiser;
        private readonly ISource<T> source;

        public Value()
            : this(default(T))
        {
        }

        public Value(T value)
            : this(new Source<T>(value))
        {
        }

        public Value(ISource<T> source)
            : this(source, Predicates<T>.Equal)
        {
        }

        public Value(ISource<T> source, Func<T, T, bool> comparer)
            : this(source, comparer, Actions.Raise)
        {
        }

        public Value(ISource<T> source, Func<T, T, bool> comparer, Action<object, IObservable> eventRaiser)
        {
            this.source = source;
            this.comparer = comparer;
            this.eventRaiser = eventRaiser;
        }

        protected virtual Func<T, T, bool> Comparer
        {
            get { return comparer; }
        }

        protected virtual Action<object, IObservable> EventRaiser
        {
            get { return eventRaiser; }
        }

        #region IValue<T> Members

        public IMessage<Null, T> Get
        {
            get { return Sources.Get<IMessage<Null, T>>("Get", CreateGet); }
        }

        public IMessage<T, Null> Set
        {
            get { return Sources.Get<IMessage<T, Null>>("Set", CreateSet); }
        }

        #endregion

        protected virtual IMessage<Null, T> CreateGet()
        {
            Func<Null, T> get = GetValue;

            return get.ToMessage().ToObservable();
        }

        protected virtual IMessage<T, Null> CreateSet()
        {
            Func<T, Null> set = SetValue;

            return set.ToMessage();
        }

        protected virtual T GetValue(Null notUsed)
        {
            return source.Value;
        }

        protected virtual Null SetValue(T request)
        {
            T previous = Get.Send(null);

            bool equal = Comparer(previous, request);

            source.Value = request;

            if (!equal)
            {
                EventRaiser(this, ((IObservable) Get));
            }

            return null;
        }
    }
}