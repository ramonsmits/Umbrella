using System;

namespace nVentive.Umbrella.Sources
{
    public class WeakSource<T> : ISource<T>
    {
        private readonly WeakReference reference;

        public WeakSource()
            : this(default(T))
        {
        }

        public WeakSource(T value)
        {
            reference = new WeakReference(value);
        }

        #region ISource<T> Members

        public virtual T Value
        {
            get
            {
                var instance = reference.Target;

                return (T) instance;
            }
            set { reference.Target = value; }
        }

        #endregion
    }
}