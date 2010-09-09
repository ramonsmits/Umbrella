using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using nVentive.Umbrella.Decorator;
using nVentive.Umbrella.Extensions;
using nVentive.Umbrella.Threading;
using nVentive.Umbrella.Collections;

namespace nVentive.Umbrella.Provider
{
    public class SynchronizedProvider<TKey, TValue> : Decorator<IProvider<TKey, TValue>>, ISynchronizable<IDictionary<TKey, TValue>>, IProvider<TKey, TValue>
    {
        private SynchronizedDictionary<TKey, TValue> items;

        public SynchronizedProvider(IProvider<TKey, TValue> target)
            : base(target)
        {
            items = new SynchronizedDictionary<TKey, TValue>(target.Items);
        }

        #region ISynchronizable<IDictionary<TKey,TValue>> Members

        public ISynchronizableLock<IDictionary<TKey, TValue>> Lock
        {
            get { return items.Lock; }
        }

        #endregion

        #region IProvider<TKey,TValue> Members

        public IDictionary<TKey, TValue> Items
        {
            get { return items; }
        }

        #endregion
    }
}
