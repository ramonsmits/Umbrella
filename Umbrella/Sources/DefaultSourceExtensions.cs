using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using nVentive.Umbrella.Messages;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Sources
{
    public class DefaultSourceExtensions : ISourceExtensions
    {
        #region ISourceExtensions Members

        public virtual ISource<T> AsReadOnly<T>(ISource<T> source)
        {
        }

        public virtual ISource<T> AsReadOnly<T>(ISource<T> source, bool throwOnSet)
        {
        }

        public virtual IMessage<Null, T> ToGetMessage<T>(ISource<T> source)
        {
        }

        public virtual IMessage<T, Null> ToSetMessage<T>(ISource<T> source)
        {
        }

        public virtual ISource<U> Adapt<T, U>(ISource<T> source)
        {
        }

        public virtual ISource<U> Adapt<T, U>(ISource<T> source, Func<U, T> from, Func<T, U> to)
        {
        }

        public virtual ISource<T?> Adapt<T>(ISource<T> source)
            where T : struct
        {
        }

        public virtual ISource<T> Adapt<T>(ISource<T?> source)
            where T : struct
        {
        }

        public virtual IDisposableSource<T> ToDisposable<T>(ISource<T> source)
        {
        }

        public virtual IDisposableSource<T> ToDisposable<T>(ISource<T> source, Action action)
        {
        }

        #endregion
    }
}
