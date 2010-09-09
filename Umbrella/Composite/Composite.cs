using System;
using System.Collections.Generic;
using System.Linq;
using nVentive.Umbrella.Collections;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Composite
{
    public class Composite<T> : ListDecorator<T>, IComposite<T>
    {
        private static readonly Func<Composite<T>, IEnumerable<object>> Fields = item => new object[] {item.Items};

        public Composite(params T[] items)
            : this((IEnumerable<T>) items)
        {
        }

        public Composite(IEnumerable<T> items)
            : this(items.ToList())
        {
        }

        public Composite(IList<T> items)
            : base(items)
        {
        }

        #region IComposite<T> Members

        public IList<T> Items
        {
            get { return Target; }
        }

        #endregion

        /// <summary>
        /// See Object pattern.
        /// </summary>
        public override int GetHashCode()
        {
            return this.Equality().GetHashCode(Fields);
        }

        /// <summary>
        /// See Object pattern.
        /// </summary>
        public override bool Equals(object obj)
        {
            return this.Equality().Equal(obj, Fields);
        }
    }
}