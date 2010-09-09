using System;
using nVentive.Umbrella.Decorator;
using nVentive.Umbrella.Events;
using nVentive.Umbrella.Messages;
using nVentive.Umbrella.Sources;

namespace nVentive.Umbrella.Values
{
    public class LazyValue<T> : Decorator<IValue<T>>, ILazyValue<T>
    {
        private readonly ILazySource<T> source;

        public LazyValue(Func<T> factory)
            : this(new LazySource<T>(factory))
        {
        }

        public LazyValue(ILazySource<T> source)
            : base(new Value<T>(source))
        {
            this.source = source;
        }

        public LazyValue(ILazySource<T> source, Func<T, T, bool> comparer)
            : base(new Value<T>(source, comparer))
        {
            this.source = source;
        }

        public LazyValue(ILazySource<T> source, Func<T, T, bool> comparer, Action<object, IObservable> eventRaiser)
            : base(new Value<T>(source, comparer, eventRaiser))
        {
            this.source = source;
            this.source.Loaded += (sender, args) => Loaded(this, EventArgs.Empty);
        }

        #region ILazyValue<T> Members

        public IMessage<Null, T> Get
        {
            get { return Target.Get; }
        }

        public IMessage<T, Null> Set
        {
            get { return Target.Set; }
        }

        public bool IsLoaded
        {
            get { return source.IsLoaded; }
        }

        public event EventHandler<EventArgs> Loaded;

        #endregion
    }
}