using System;
using System.Collections;
using System.Collections.Generic;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella
{
    /// <summary>
    /// Represents a Key concept.
    /// </summary>
    public class Key
    {
        private static readonly Func<Key, IEnumerable<object>> Fields = item => item.Items;

        /// <summary>
        /// Constucts a new Key with an array of items.
        /// </summary>
        /// <param name="items"></param>
        public Key(params object[] items)
        {
            Items = items;
        }

        /// <summary>
        /// Constucts a new Key with an enumeration of items.
        /// </summary>
        /// <param name="items"></param>
        public Key(IEnumerable items)
            : this(items.ToObjectArray())
        {
        }

        public object[] Items { get; private set; }

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