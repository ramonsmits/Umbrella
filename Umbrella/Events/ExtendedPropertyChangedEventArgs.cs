using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace nVentive.Umbrella.Events
{
    public class ExtendedPropertyChangedEventArgs<T> : PropertyChangedEventArgs
    {
        public ExtendedPropertyChangedEventArgs(string propertyName)
            : base(propertyName)
        {
        }

        public ExtendedPropertyChangedEventArgs(string propertyName, T oldValue, T newValue)
            : this(propertyName)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }

        public T OldValue { get; private set; }

        public T NewValue { get; private set; }
    }
}
