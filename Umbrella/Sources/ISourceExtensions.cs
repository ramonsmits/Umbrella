using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nVentive.Umbrella.Messages;

namespace nVentive.Umbrella.Sources
{
    public interface ISourceExtensions
    {
        ISource<T> AsReadOnly<T>(ISource<T> source);
        ISource<T> AsReadOnly<T>(ISource<T> source, bool throwOnSet);

        ISource<U> Adapt<T, U>(ISource<T> source);
        ISource<U> Adapt<T, U>(ISource<T> source, Func<U, T> from, Func<T,U> to);
        
        ISource<T?> Adapt<T>(ISource<T> source)
            where T : struct;
        
        ISource<T> Adapt<T>(ISource<T?> source)
            where T : struct;

        IDisposableSource<T> ToDisposable<T>(ISource<T> source);
        IDisposableSource<T> ToDisposable<T>(ISource<T> source, Action action);

        IMessage<Null, T> ToGetMessage<T>(ISource<T> source);
        IMessage<T, Null> ToSetMessage<T>(ISource<T> source);
    }
}
