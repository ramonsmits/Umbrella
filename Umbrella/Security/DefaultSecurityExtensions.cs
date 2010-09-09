using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nVentive.Umbrella.Contexts;
using nVentive.Umbrella.Extensions;
using nVentive.Umbrella.Contracts;
using System.Security;

namespace nVentive.Umbrella.Security
{
    public class DefaultSecurityExtensions : ISecurityExtensions
    {
        #region ISecurityExtensions Members

        public virtual SecurityExtensionPoint Security(IContext context)
        {
            return new SecurityExtensionPoint(context);
        }

        public bool IsAuthorized(SecurityExtensionPoint extensionPoint, string context)
        {
            return extensionPoint.ExtendedValue.GetService<IAuthorizationService>().IsAuthorized(CreateContract(context));
        }

        public void Authorize(SecurityExtensionPoint extensionPoint, string context)
        {
            if (!IsAuthorized(extensionPoint, context))
            {
                throw new SecurityException(); //TODO Replace with same exception as PIAB Authorization CallHandler?
            }
        }

        #endregion

        protected virtual IContract CreateContract(string context)
        {
            return new NameContract(context);
        }

    }
}
