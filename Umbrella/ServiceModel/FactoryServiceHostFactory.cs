using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Activation;
using System.ServiceModel;

namespace Nventive.Framework.ServiceModel
{
    public class FactoryServiceHostFactory : ServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            return new FactoryServiceHost(serviceType, baseAddresses);
        }
    }
}
