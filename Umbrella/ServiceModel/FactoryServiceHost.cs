using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Nventive.Framework.Extensions;
using Nventive.Framework.Contexts;

namespace Nventive.Framework.ServiceModel
{
    public class FactoryServiceHost : ServiceHost
    {
        public FactoryServiceHost(Type serviceType, params string[] baseAddresses)
            : this(serviceType, baseAddresses.Select(item => new Uri(item)).ToArray())
        {
        }

        public FactoryServiceHost(Type serviceType, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
        }

        protected override void OnOpening()
        { 
            Description.Behaviors.Add(Context.Instance.Factory().Create<FactoryServiceBehavior>());

            base.OnOpening();
        }
    }
}
