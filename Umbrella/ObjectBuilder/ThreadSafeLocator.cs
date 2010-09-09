//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Microsoft.Practices.ObjectBuilder;
//using Nventive.Framework.Decorator;
//using Nventive.Framework.Threading;
//using System.Threading;

//namespace Nventive.Framework.ObjectBuilder
//{
//    public class ThreadSafeLocator : Decorator<IReadWriteLocator>, IReadWriteLocator, ISynchronizable
//    {
//        private ReaderWriter readWrite = new ReaderWriter();

//        public ThreadSafeLocator()
//            : this(new Locator())
//        {
//        }

//        public ThreadSafeLocator(IReadWriteLocator decoratee)
//            : base(decoratee)
//        {
//        }

//        #region IReadWriteLocator Members

//        public void Add(object key, object value)
//        {
//            readWrite.Write(() => Decoratee.Add(key, value));
//        }

//        public bool Remove(object key)
//        {
//            return readWrite.Write(() => Decoratee.Remove(key));
//        }

//        #endregion

//        #region IReadableLocator Members

//        public bool Contains(object key, SearchMode options)
//        {
//            return readWrite.Read(() => Decoratee.Contains(key, options));
//        }

//        public bool Contains(object key)
//        {
//            return readWrite.Read(() => Decoratee.Contains(key));
//        }

//        public int Count
//        {
//            get { return readWrite.Read(() => Decoratee.Count); }
//        }

//        public IReadableLocator FindBy(SearchMode options, Predicate<KeyValuePair<object, object>> predicate)
//        {
//            return readWrite.Read(() => Decoratee.FindBy(options, predicate));
//        }

//        public IReadableLocator FindBy(Predicate<KeyValuePair<object, object>> predicate)
//        {
//            return readWrite.Read(() => Decoratee.FindBy(predicate));
//        }

//        public object Get(object key, SearchMode options)
//        {
//            return readWrite.Read(() => Decoratee.Get(key, options));
//        }

//        public object Get(object key)
//        {
//            return readWrite.Read(() => Decoratee.Get(key));
//        }

//        public TItem Get<TItem>(object key, SearchMode options)
//        {
//            return readWrite.Read(() => Decoratee.Get<TItem>(key, options));
//        }

//        public TItem Get<TItem>(object key)
//        {
//            return readWrite.Read(() => Decoratee.Get<TItem>(key));
//        }

//        public TItem Get<TItem>()
//        {
//            return readWrite.Read(() => Decoratee.Get<TItem>());
//        }

//        public IReadableLocator ParentLocator
//        {
//            get { return readWrite.Read(() => Decoratee.ParentLocator); }
//        }

//        public bool ReadOnly
//        {
//            get { return readWrite.Read(() => Decoratee.ReadOnly); }
//        }

//        #endregion

//        #region IEnumerable<KeyValuePair<object,object>> Members

//        public IEnumerator<KeyValuePair<object, object>> GetEnumerator()
//        {
//            return readWrite.Read(() => Decoratee.ToList().GetEnumerator());
//        }

//        #endregion

//        #region IEnumerable Members

//        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
//        {
//            return GetEnumerator();
//        }

//        #endregion

//        #region ISynchronizable Members

//        public ReaderWriterLock Lock
//        {
//            get { return readWrite.Lock; }
//        }

//        #endregion
//    }
//}
