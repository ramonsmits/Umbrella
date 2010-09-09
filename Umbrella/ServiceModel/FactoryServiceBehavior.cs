using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Description;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;

using Nventive.Framework.Extensions;
using Nventive.Framework.Components;

namespace Nventive.Framework.ServiceModel
{
    public class FactoryServiceBehavior : Component, IServiceBehavior
    {
        #region IServiceBehavior Members

        public virtual void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            object[] args = new[] { serviceDescription.ServiceType };

            IInstanceProvider provider = Context.Factory().Create<FactoryInstanceProvider>(args);

            serviceHostBase
                .ChannelDispatchers
                .OfType<ChannelDispatcher>()
                .SelectMany(item => item.Endpoints)
                .ForEach(item => item.DispatchRuntime.InstanceProvider = provider);
        }

        public virtual void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }

        #endregion
    }
}
