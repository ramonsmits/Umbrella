using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ObjectBuilder;

using Nventive.Framework.Extensions;


using Nventive.Framework.Decorator;

namespace Nventive.Framework.ObjectBuilder
{
    //TODO Extract ReadWriteLocatorDecorator base class...
    public class LifetimeLocator : Decorator<IReadWriteLocator>, IReadWriteLocator, IDisposable
    {
        private ILifetimeContainer container;

        public LifetimeLocator(IReadWriteLocator decoratee)
            : this(decoratee, new LifetimeContainer())
        {
        }

        public LifetimeLocator(IReadWriteLocator decoratee, ILifetimeContainer container)
            : base(decoratee)
        {
            this.container = container.Validation().NotNull("container");
        }

        #region IReadWriteLocator Members

        public void Add(object key, object value)
        {
            container.Add(value);

            Decoratee.Add(key, value);
        }

        public bool Remove(object key)
        {
            object item = Get(key);
            container.Remove(item);

            return Decoratee.Remove(key);
        }

        #endregion

        #region IReadableLocator Members

        public bool Contains(object key)
        {
            return Decoratee.Contains(key);
        }

        public int Count
        {
            get { return Decoratee.Count; }
        }

        public IReadableLocator FindBy(Predicate<KeyValuePair<object, object>> predicate)
        {
            return Decoratee.FindBy(predicate);
        }

        public object Get(object key)
        {
            return Decoratee.Get(key);
        }

        public TItem Get<TItem>(object key)
        {
            return Decoratee.Get<TItem>(key);
        }

        public TItem Get<TItem>()
        {
            return Decoratee.Get<TItem>();
        }

        public IReadableLocator ParentLocator
        {
            get { return Decoratee.ParentLocator; }
        }

        public bool ReadOnly
        {
            get { return Decoratee.ReadOnly; }
        }

        #endregion

        #region IEnumerable<KeyValuePair<object,object>> Members

        public IEnumerator<KeyValuePair<object, object>> GetEnumerator()
        {
            return Decoratee.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return Decoratee.GetEnumerator();
        }

        #endregion

        #region IDisposable Members

        public virtual void Dispose()
        {
            container.Dispose();
        }

        #endregion
    }
}
