using System;

namespace nVentive.Umbrella
{
    public class Predicates
    {
        public static readonly Func<object, object, bool> Equal = Predicates<object>.Equal;
        public static readonly Func<object, object, bool> ReferenceEqual = Predicates<object>.ReferenceEqual;
    }
}