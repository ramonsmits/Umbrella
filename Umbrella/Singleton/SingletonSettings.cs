using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace nVentive.Framework.Patterns.Singleton
{
    public class SingletonSettings : SerializableConfigurationSection
    {
        public static string SectionName = "singletonConfiguration";

        private const string MappingsPropertyName = "mappings";

        [ConfigurationProperty(MappingsPropertyName, IsRequired=true)]
        public NamedElementCollection<SingletonTypeMappingData> Mappings
        {
            get { return (NamedElementCollection<SingletonTypeMappingData>)base[MappingsPropertyName]; }
            set { base[MappingsPropertyName] = value; }
        }
    }
}
