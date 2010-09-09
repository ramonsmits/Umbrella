using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Dispatcher;
using System.ServiceModel;
using Nventive.Framework.Components;

using Nventive.Framework.Extensions;
using Nventive.Framework.Containers;

namespace Nventive.Framework.ServiceModel
{
    public class FactoryInstanceProvider : Container, IInstanceProvider
    {
        private Type type;

        public FactoryInstanceProvider(Type type)
        {
            this.type = type;
        }

        #region IInstanceProvider Members

        public virtual object GetInstance(InstanceContext instanceContext, System.ServiceModel.Channels.Message message)
        {
            return Context.Factory().Create(type);
        }

        public virtual object GetInstance(InstanceContext instanceContext)
        {
            return GetInstance(instanceContext, null);
        }

        public virtual void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
        }

        #endregion
    }
}
