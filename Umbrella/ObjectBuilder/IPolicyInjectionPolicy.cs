using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjectBuilder;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace Nventive.Framework.ObjectBuilder
{
    public interface IPolicyInjectionPolicy : IBuilderPolicy
    {
        bool ApplyPolicies { get; }

        object ApplyProxy(object instanceToProxy, Type typeToProxy);
        void SetPolicyConfigurationSource(IConfigurationSource configSource);
    }
}
