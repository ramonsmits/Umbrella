using System;

namespace nVentive.Umbrella.Extensions
{
    public class ExtensionPoint<T> : IExtensionPoint<T>
    {
        private readonly Type type;
        private readonly T value;

        public ExtensionPoint(T value)
        {
            this.value = value;
        }

        public ExtensionPoint(Type type)
        {
            this.type = type;
        }

        #region IExtensionPoint<T> Members

        public T ExtendedValue
        {
            get { return value; }
        }

        object IExtensionPoint.ExtendedValue
        {
            get { return value; }
        }

        public Type ExtendedType
        {
            // TODO: value might not be null
            get { return type ?? (value == null ? typeof (T) : value.GetType()); }
        }

        #endregion
    }
}