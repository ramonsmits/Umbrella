using System;
using System.Collections.Generic;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Sources
{
    public class Source<T> : ISource<T>
    {
        private static readonly Func<Source<T>, IEnumerable<object>> Fields = item => new object[] {item.Value};

        private T value;

        public Source()
            : this(default(T))
        {
        }

        public Source(T value)
        {
            this.value = value;
        }

        #region ISource<T> Members

        public virtual T Value
        {
            get { return value; }
            set { this.value = value; }
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

        public override string ToString()
        {
            return string.Format("Value: {0}", value);
        }
    }
}