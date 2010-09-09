using System;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Sources
{
    public static class LazySource
    {
        public static LazySource<T> New<T>()
            where T : new()
        {
            return New<T>(LazyBehavior.Loaded);
        }

        public static LazySource<T> New<T>(LazyBehavior behavior)
            where T : new()
        {
            return new LazySource<T>(behavior, () => new T());
        }
    }

    public class LazySource<T> : SourceDecorator<T>, ILazySource<T>
    {
        private readonly LazyBehavior behavior;
        private readonly Func<T> factory;
        private bool loaded;

        public LazySource()
            : this(Funcs<T>.Default)
        {
        }

        public LazySource(Func<T> factory)
            : this(new Source<T>(), factory)
        {
        }

        public LazySource(ISource<T> target, Func<T> factory)
            : this(target, LazyBehavior.Loaded, factory)
        {
        }

        public LazySource(LazyBehavior behavior)
            : this(behavior, Funcs<T>.Default)
        {
        }

        public LazySource(LazyBehavior behavior, Func<T> factory)
            : this(new Source<T>(), behavior, factory)
        {
        }

        public LazySource(ISource<T> target, LazyBehavior behavior, Func<T> factory)
            : base(target)
        {
            this.factory = factory;
            this.behavior = behavior;
            Loaded = (sender, args) => { };
        }

        protected virtual Func<T> Factory
        {
            get { return factory; }
        }

        #region ILazySource<T> Members

        public override T Value
        {
            get
            {
                if (!IsLoaded)
                {
                    Value = Factory();
                    CreatedUsingFactory = true;
                    Loaded(this, EventArgs.Empty);
                }

                return base.Value;
            }
            set
            {
                base.Value = value;
                IsLoaded = true;
                CreatedUsingFactory = false;
            }
        }

        public bool CreatedUsingFactory
        {
            get;
            private set;
        }

        public virtual bool IsLoaded
        {
            get
            {
                switch (behavior)
                {
                    case LazyBehavior.Loaded:
                        return loaded;

                    case LazyBehavior.Null:
                        // TODO: Possible compare type with value
                        return Target.Value != null;

                    case LazyBehavior.Default:
                        return !Target.Value.Extensions().IsDefault();

                    default:
                        throw new NotSupportedException();
                }
            }
            set
            {
                if (behavior == LazyBehavior.Loaded)
                {
                    loaded = value;
                }
            }
        }

        public event EventHandler<EventArgs> Loaded;

        #endregion

        public override string ToString()
        {
            return string.Format("Value: {0}", IsLoaded ? (object) Value : "[Not Loaded]");
        }
    }
}