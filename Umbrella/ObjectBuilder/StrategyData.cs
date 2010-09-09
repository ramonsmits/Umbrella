using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

using ObjectBuilder;

using Nventive.Framework.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace Nventive.Framework.ObjectBuilder
{
    public class StrategyData : NameTypeConfigurationElement
    {
        private const string StatePropertyName = "stage";

        [ConfigurationProperty(StatePropertyName, IsRequired=true)]
        public BuilderStage Stage
        {
            get { return (BuilderStage)this[StatePropertyName]; }
            set { this[StatePropertyName] = value; }
        }
    }
}
