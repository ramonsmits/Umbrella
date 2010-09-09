using nVentive.Umbrella.Extensions;
using nVentive.Umbrella.Sources;

namespace nVentive.Umbrella.Values
{
    public class ValueSource<T> : ISource<T>
    {
        private readonly IValue<T> value;

        public ValueSource(IValue<T> value)
        {
            this.value = value;
        }

        #region ISource<T> Members

        public T Value
        {
            get { return value.Get(); }
            set { this.value.Set(value); }
        }

        #endregion
    }
}