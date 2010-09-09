using System;

namespace nVentive.Umbrella.Sources
{
    public class DisposableSource<T> : SourceDecorator<T>, IDisposableSource<T>
    {
        private readonly Action diposeAction;

        public DisposableSource(ISource<T> target)
            : this(target, null)
        {
        }

        public DisposableSource(ISource<T> target, Action disposeAction)
            : base(target)
        {
            diposeAction = disposeAction;
        }

        #region IDisposableSource<T> Members

        public void Dispose()
        {
            if (diposeAction == null)
            {
                Value = default(T);
            }
            else
            {
                diposeAction();
            }
        }

        #endregion
    }
}