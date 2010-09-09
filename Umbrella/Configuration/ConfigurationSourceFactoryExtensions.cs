using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace nVentive.Framework.Configuration
{
    public static class ConfigurationSourceFactoryExtensions
    {
        //TODO Use Extensions pattern.
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
    }
}
