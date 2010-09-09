using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

using ObjectBuilder;

using Nventive.Framework.Collections;
using Nventive.Framework.Contexts;
using Nventive.Framework.Extensions;
using Nventive.Framework.ObjectBuilder;
using System.Diagnostics;

namespace Nventive.Framework.Factories
{
    [ConfigurationElementType(typeof(FactoryContextData))]
    public class FactoryContextData : ContextEntryData
    {
        private const string StrategiesPropertyName = "strategies";

        [ConfigurationProperty(StrategiesPropertyName)]
        public virtual NamedElementCollection<StrategyData> Strategies
        {
            get { return (NamedElementCollection<StrategyData>)this[StrategiesPropertyName]; }
            set { this[StrategiesPropertyName] = value; }
        }

        public override void Initialize(IContext context)
        {
            base.Initialize(context);

            IFactoryContext factoryContext = CreateFactoryContext();

            factoryContext.Policies.SetDefault<IPolicyInjectionPolicy>(new PolicyInjectionPolicy(true));

            context.AddService<IFactoryContext>(factoryContext);
        }

        protected virtual IStrategyChain CreateStrategyChain()
        {
            StagedStrategyChain<BuilderStage> strategies = new StagedStrategyChain<BuilderStage>();

            Strategies.ForEach(item => strategies.Add(CreateStrategy(item.Type), item.Stage));

            return strategies.MakeStrategyChain();
        }

        protected virtual IBuilderStrategy CreateStrategy(Type type)
        {
            return type.CreateInstance<IBuilderStrategy>();
        }

        protected virtual IFactoryContext CreateFactoryContext()
        {
            IStrategyChain strategies = CreateStrategyChain();

            return new FactoryContext(strategies);
        }
    }
}
