using System;
using System.Collections.Generic;

namespace nVentive.Umbrella.Collections
{
    public class LazyList<T> : ListDecorator<T>
    {
        public LazyList(Func<IList<T>> factory)
            : base(null)
        {
            Factory = factory;
        }

        public Func<IList<T>> Factory { get; private set; }

        public override IList<T> Target
        {
            get
            {
                var list = base.Target;

                if (list == null)
                {
                    Target = list = Factory();
                }

                return list;
            }
            set { base.Target = value; }
        }
    }
}