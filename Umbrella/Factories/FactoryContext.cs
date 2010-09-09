using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ObjectBuilder;

using Nventive.Framework.Extensions;


namespace Nventive.Framework.Factories
{
    public class FactoryContext : IFactoryContext
    {
        private PolicyList policies;
        private IStrategyChain strategies;

        public FactoryContext()
            : this(new StrategyChain())
        {
        }

        public FactoryContext(IStrategyChain strategies)
            : this(new PolicyList(), strategies)
        {
        }

        public FactoryContext(PolicyList policies, IStrategyChain strategies)
        {
            this.policies = policies.Validation().NotNull("policies");
            this.strategies = strategies.Validation().NotNull("strategies");
        }

        #region IFactoryContext Members

        public PolicyList Policies
        {
            get { return policies; }
        }

        public IStrategyChain Strategies
        {
            get { return strategies; }
        }

        #endregion
    }
}
