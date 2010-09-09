using System;
using nVentive.Umbrella.Decorator;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Sources
{
    public class SourceAdapter<T, U> : Decorator<ISource<T>>, ISource<U>
    {
        private readonly Func<U, T> from;
        private readonly Func<T, U> to;

        public SourceAdapter(ISource<T> target)
            : this(target, Funcs<U, T>.Convert, Funcs<T, U>.Convert)
        {
        }

        /// <summary>
        /// Constructs a SourceAdapter
        /// </summary>
        /// <param name="target">Collection of type T to adapt.</param>
        /// <param name="from">Function used to adapt a U into a T.</param>
        /// <param name="to">Function used to adapt a T into a U.</param>
        public SourceAdapter(ISource<T> target, Func<U, T> from, Func<T, U> to)
            : base(target)
        {
            this.from = from.Validation().NotNull("from");
            this.to = to.Validation().NotNull("to");
        }

        #region ISource<U> Members

        public U Value
        {
            get { return to(Target.Value); }
            set { Target.Value = from(value); }
        }

        #endregion
    }
}