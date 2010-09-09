using nVentive.Umbrella.Decorator;

namespace nVentive.Umbrella.Sources
{
    public class SourceDecorator<T> : Decorator<ISource<T>>, ISource<T>
    {
        public SourceDecorator()
        {
        }

        public SourceDecorator(ISource<T> target)
            : base(target)
        {
        }

        #region ISource<T> Members

        public virtual T Value
        {
            get { return Target.Value; }
            set { Target.Value = value; }
        }

        #endregion
    }
}