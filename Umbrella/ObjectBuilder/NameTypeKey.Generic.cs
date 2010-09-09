using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nVentive.Framework.ObjectBuilder
{
    public class NameTypeBuildKey<T> : NameTypeKey
    {
        public NameTypeBuildKey(string name)
            : base(name, typeof(T))
        {
        }
    }
}
