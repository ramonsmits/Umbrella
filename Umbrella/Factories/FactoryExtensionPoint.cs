using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nVentive.Umbrella.Extensions;
using nVentive.Umbrella.Locator;

namespace nVentive.Umbrella.Factories
{
    public class FactoryExtensionPoint : ExtensionPoint<IServiceLocator>
    {
        public FactoryExtensionPoint(IServiceLocator locator)
            : base(locator)
        {
        }
    }
}
