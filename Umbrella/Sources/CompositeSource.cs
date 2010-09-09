using System;
using System.Collections.Generic;
using System.Linq;
using nVentive.Umbrella.Composite;

namespace nVentive.Umbrella.Sources
{
    public class CompositeSource<T> : Composite<ISource<T>>, ISource<T>
    {
        private readonly Func<T, bool> predicate;

        public CompositeSource(params ISource<T>[] items)
            : this(Funcs<T>.IsNotDefault, items)
        {
        }

        public CompositeSource(Func<T, bool> predicate, params ISource<T>[] items)
            : this(predicate, (IEnumerable<ISource<T>>) items)
        {
        }

        public CompositeSource(Func<T, bool> predicate, IEnumerable<ISource<T>> items)
            : base(items)
        {
            this.predicate = predicate;
        }

        #region ISource<T> Members

        public T Value
        {
            get { return Items.Select(item => item.Value).Where(predicate).FirstOrDefault(); }
            set { throw new ReadOnlyException(); }
        }

        #endregion
    }
}