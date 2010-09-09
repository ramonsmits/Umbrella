using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nVentive.Umbrella.Contexts;

namespace nVentive.Umbrella.Security
{
    public interface ISecurityExtensions
    {
        SecurityExtensionPoint Security(IContext context);
        bool IsAuthorized(SecurityExtensionPoint extensionPoint, string context);
        void Authorize(SecurityExtensionPoint extensionPoint, string context);
    }
}
