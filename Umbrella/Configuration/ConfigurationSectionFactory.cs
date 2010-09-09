using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

using nVentive.Framework.Patterns.Singleton;

namespace nVentive.Framework.Configuration
{
    public class ConfigurationSectionFactory
    {
        public static T Create<T>(string sourceName, string sectionName)
            where T : ConfigurationSection
        {
        }
    }
}
