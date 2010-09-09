using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nVentive.Umbrella.Contexts;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Security
{
    public class SecurityExtensionPoint : ExtensionPoint<IContext>
    {
        public SecurityExtensionPoint(IContext context)
            : base(context)
        {
        }
    }
}
