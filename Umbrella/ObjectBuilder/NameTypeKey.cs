using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ObjectBuilder;

namespace nVentive.Framework.ObjectBuilder
{
    public class NameTypeKey : TypeKey
    {
        private string name;

        public NameTypeKey(string name, Type type)
            : base(type)
        {
            this.name = name;
        }

        public virtual string Name
        {
            get { return name; }
        }
    }
}
