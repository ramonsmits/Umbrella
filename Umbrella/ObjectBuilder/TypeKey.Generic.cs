using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nVentive.Framework.ObjectBuilder
{
    public class TypeBuildKey<T> : TypeKey
    {
        public TypeBuildKey()
            : base(typeof(T))
        {
        }
    }
}
