using System;
using System.Collections.Generic;
using System.Linq;

namespace nVentive.Umbrella
{
    public static class FieldsExtensions
    {
        public static Func<TDerived, IEnumerable<object>> Concat<TBase, TDerived>(
            this Func<TBase, IEnumerable<object>> baseFields, Func<TDerived, IEnumerable<object>> derivedFields)
            where TDerived : TBase
        {
            return item => baseFields(item).Concat(derivedFields(item));
        }
    }
}