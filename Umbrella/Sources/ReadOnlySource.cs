using nVentive.Umbrella.Decorator;

namespace nVentive.Umbrella.Sources
{
    public class ReadOnlySource<T> : Decorator<ISource<T>>, ISource<T>
    {
        public ReadOnlySource(ISource<T> target)
            : this(target, true)
        {
        }

        public ReadOnlySource(ISource<T> target, bool throwOnSet)
            : base(target)
        {
            ThrowOnSet = throwOnSet;
        }

        public bool ThrowOnSet { get; set; }

        #region ISource<T> Members

        public virtual T Value
        {
            get { return Target.Value; }
            set
            {
                if (ThrowOnSet)
                {
                    throw new ReadOnlyException();
                }
            }
        }

        #endregion
    }
}