using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nVentive.Umbrella.Factories;
using nVentive.Umbrella.Extensions;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using nVentive.Umbrella.Contracts;

namespace nVentive.Umbrella.EnterpriseLibrary.Configuration
{
    public class ConfigurationSourceFactoryStrategy : FactoryStrategyBase
    {
        public static IConfigurationSource Create(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return ConfigurationSourceFactory.Create();
            }
            else
            {
                return ConfigurationSourceFactory.Create(name);
            }
        }

        protected override bool CanFullfill(Type type, string name, IContract contract)
        {
            return type.Is<IConfigurationSource>();
        }

        protected override object Create(Type type, string name, IContract contract)
        {
            return Create(name);
        }
    }
}
