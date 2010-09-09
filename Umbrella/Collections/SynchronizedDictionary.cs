using System.Collections;
using System.Collections.Generic;
using System.Linq;
using nVentive.Umbrella.Decorator;
using nVentive.Umbrella.Extensions;
using nVentive.Umbrella.Threading;
using System;

namespace nVentive.Umbrella.Collections
{
    [Serializable]
    public class SynchronizedDictionary<TKey, TValue> : Decorator<IDictionary<TKey, TValue>>, IDictionary<TKey, TValue>,
                                                        ISynchronizable<IDictionary<TKey, TValue>>
    {
        private readonly Synchronizable<IDictionary<TKey, TValue>> target;

        public SynchronizedDictionary(IDictionary<TKey, TValue> target)
            : base(target)
        {
            this.target = new Synchronizable<IDictionary<TKey, TValue>>(target);
        }

        public SynchronizedDictionary()
            : this(new Dictionary<TKey, TValue>())
        {

        }

        #region IDictionary<TKey,TValue> Members

        public void Add(TKey key, TValue value)
        {
            Lock.Write(item => item.Add(key, value));
        }

        public bool ContainsKey(TKey key)
        {
            return Lock.Read(item => item.ContainsKey(key));
        }

        public ICollection<TKey> Keys
        {
            get { return Lock.Read(item => item.Keys.ToList()); }
        }

        public bool Remove(TKey key)
        {
            return Lock.Write(item => item.Remove(key));
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            TValue tempValue = default(TValue);

            bool found = Lock.Read(item => item.TryGetValue(key, out tempValue));

            value = tempValue;

            return found;
        }

        public ICollection<TValue> Values
        {
            get { return Lock.Read(item => item.Values.ToList()); }
        }

        public TValue this[TKey key]
        {
            get { return Lock.Read(item => item[key]); }
            set { Lock.Write(item => item[key] = value); }
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Lock.Write(dec => dec.Add(item));
        }

        public void Clear()
        {
            Lock.Write(item => item.Clear());
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return Lock.Read(dec => dec.Contains(item));
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            Lock.Read(item => item.CopyTo(array, arrayIndex));
        }

        public int Count
        {
            get { return Lock.Read(item => item.Count); }
        }

        public bool IsReadOnly
        {
            get { return Lock.Read(item => item.IsReadOnly); }
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return Lock.Write(dec => dec.Remove(item));
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return Lock.Read(item => item.ToList().GetEnumerator());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region ISynchronizable<IDictionary<TKey,TValue>> Members

        public ISynchronizableLock<IDictionary<TKey, TValue>> Lock
        {
            get { return target.Lock; }
        }

        #endregion
    }
}