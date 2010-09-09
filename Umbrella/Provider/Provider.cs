using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nVentive.Umbrella.Provider
{
    public class Provider<TKey, TValue> : IProvider<TKey, TValue>
    {
        private IDictionary<TKey, TValue> items;

        public Provider()
            : this(new Dictionary<TKey, TValue>())
        {
        }

        public Provider(IDictionary<TKey, TValue> items)
        {
            this.items = items;
        }

        #region IProvider<TKey,TValue> Members

        public virtual IDictionary<TKey, TValue> Items 
        {
            get { return items; }
        }

        #endregion
    }
}
