using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Security
{
    public static class SecurityExtensions
    {
        public static ISecurityExtensions Extensions
        {
            get { return ExtensionsProvider.GetExtensions<ISecurityExtensions, DefaultSecurityExtensions>(); }
        }
    }
}
