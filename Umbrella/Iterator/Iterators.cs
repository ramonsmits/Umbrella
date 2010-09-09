using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nVentive.Umbrella.Iterators
{
    /// <summary>
    /// Container for stock iterators.
    /// </summary>
    public static class Iterators
    {
        /// <summary>
        /// A iterator that navigates from a Type to it's base Type.
        /// </summary>
        public static readonly Func<Type, Type> BaseTypeIterator = type => type.BaseType;
    }
}
