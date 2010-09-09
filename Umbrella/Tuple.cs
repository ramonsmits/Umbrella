using System;
using System.Collections.Generic;
using nVentive.Umbrella.Components;

namespace nVentive.Umbrella
{
    public class Tuple<TValue, UValue> : Component
    {
        public static readonly Func<Tuple<TValue, UValue>, IEnumerable<object>> FieldsEnumerator =
            item => new object[] {item.T, item.U};

        public TValue T { get; set; }

        public UValue U { get; set; }

        protected override IEnumerable<object> Fields
        {
            get { return FieldsEnumerator(this); }
        }
    }

    public class Tuple<TValue, UValue, VValue> : Tuple<TValue, UValue>
    {
        public new static readonly Func<Tuple<TValue, UValue, VValue>, IEnumerable<object>> FieldsEnumerator =
            Tuple<TValue, UValue>.FieldsEnumerator.Concat<Tuple<TValue, UValue>, Tuple<TValue, UValue, VValue>>(
                item => new object[] {item.V});

        public VValue V { get; set; }

        protected override IEnumerable<object> Fields
        {
            get { return FieldsEnumerator(this); }
        }
    }
}