using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace nVentive.Umbrella.EnterpriseLibrary.Configuration
{
    public class ConfigurationResolverSettings : SerializableConfigurationSection
    {
        private const string SectionsPropertyName = "sections";

        [ConfigurationProperty(SectionsPropertyName, IsRequired = true)]
        public NamedElementCollection<ConfigurationResolverEntryData> Sections
        {
            get { return (NamedElementCollection<ConfigurationResolverEntryData>)this[SectionsPropertyName]; }
        }
    }
}
