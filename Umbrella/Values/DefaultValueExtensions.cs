using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nVentive.Umbrella.Sources;
using nVentive.Umbrella.Events;
using nVentive.Umbrella.Messages;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Values
{
    public class DefaultValueExtensions : IValueExtensions
    {
        #region IValueExtensions Members

        public virtual T Get<T>(IValue<T> instance)
        {
        }

        public virtual void Set<T>(IValue<T> instance, T value)
        {
        }

        public virtual IDisposable Bind<T>(IValue<T> first, IValue<T> second)
        {
        }

        public virtual IDisposable Observe<T>(IValue<T> value, EventHandler<EventArgs> handler)
        {
        }

        public virtual IValue<T> ToValue<T>(nVentive.Umbrella.Sources.ISource<T> source)
        {
        }

        public virtual ISource<T> ToSource<T>(IValue<T> value)
        {
        }

        #endregion
    }
}
