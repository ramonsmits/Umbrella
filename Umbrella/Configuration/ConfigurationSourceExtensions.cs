using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

using nVentive.Umbrella.EnterpriseLibrary.Configuration;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.EnterpriseLibrary.Configuration
{
    public static class ConfigurationSourceExtensions
    {
        public static IConfigurationSourceExtensions Extensions
        {
            get { return ExtensionsProvider.GetExtensions<IConfigurationSourceExtensions, DefaultConfigurationSourceExtensions>(); }
        }

        public static T FindSection<T>(this IConfigurationSource configSource, string sectionName)
            where T : ConfigurationSection
        {
            return Extensions.FindSection<T>(configSource, sectionName);
        }
    }
}
