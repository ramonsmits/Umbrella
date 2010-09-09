using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nVentive.Umbrella.Edm
{
    [AttributeUsage(AttributeTargets.Class)]
    public class EntitySetAttribute : Attribute
    {
        public string Name
        {
            get;
            set;
        }
    }
}
