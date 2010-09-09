using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.ObjectBuilder;
using Nventive.Framework.Proxies;
using ObjectBuilder;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace Nventive.Framework.ObjectBuilder
{
    public class PolicyInjectionStrategy : BuilderStrategy
    {
        public override object BuildUp(IBuilderContext context, object buildKey, object existing)
        {
            object buildObject = base.BuildUp(context, buildKey, existing);

            IPolicyInjectionPolicy policyInjectionPolicy = context.Policies.Get<IPolicyInjectionPolicy>(buildKey);

            if (policyInjectionPolicy != null && policyInjectionPolicy.ApplyPolicies)
            {
                policyInjectionPolicy.SetPolicyConfigurationSource(GetConfigurationSource(context));

                Type typeToBuild;
                TryGetTypeFromBuildKey(buildKey, out typeToBuild);

                object newBuildObject = policyInjectionPolicy.ApplyProxy(buildObject, typeToBuild);

                if (!Object.ReferenceEquals(newBuildObject, buildObject))
                {
                    IProxyable proxyable = newBuildObject as IProxyable;

                    if (proxyable != null)
                    {
                        proxyable.Proxy = newBuildObject;
                    }
                }

                buildObject = newBuildObject;
            }

            return buildObject;
        }

        protected IConfigurationSource GetConfigurationSource(IBuilderContext context)
        {
            return new SystemConfigurationSource(); //TODO Get Source from somewhere (ConfigurationSettings)
        }
    }
}
