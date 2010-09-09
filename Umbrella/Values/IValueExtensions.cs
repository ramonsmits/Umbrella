using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nVentive.Umbrella.Sources;

namespace nVentive.Umbrella.Values
{
    public interface IValueExtensions
    {
        T Get<T>(IValue<T> instance);

        void Set<T>(IValue<T> instance, T value);

        IDisposable Bind<T>(IValue<T> first, IValue<T> second);

        IDisposable Observe<T>(IValue<T> value, EventHandler<EventArgs> handler);

        IValue<T> ToValue<T>(ISource<T> source);

        ISource<T> ToSource<T>(IValue<T> value);
    }
}
