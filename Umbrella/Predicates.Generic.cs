using System;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella
{
    public class Predicates<T>
    {
        public static readonly Func<T, T, bool> Equal = (x, y) => x.Equality().Equal(y);

        // TODO: can be replaced by method group?
        public static readonly Func<T, T, bool> ReferenceEqual = (x, y) => ReferenceEqual(x, y);
    }
}