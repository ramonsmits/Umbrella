using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ObjectBuilder;

using Nventive.Framework.Contracts;

namespace Nventive.Framework.Factories
{
    public class TransientPoliciesContract : SourceContract<PolicyList>
    {
        public TransientPoliciesContract()
        {
        }

        public TransientPoliciesContract(PolicyList policies)
            : base(policies)
        {
        }
    }
}
