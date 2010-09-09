using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

using nVentive.Umbrella.EnterpriseLibrary.Configuration;

namespace nVentive.Umbrella.Extensions
{
    public class ExtensionsSettings : SerializableConfigurationSection
    {
        private const string MappingsPropertyName = "mappings";

        //TODO Use TypedElementCollection instead.
        [ConfigurationProperty(MappingsPropertyName, IsRequired = true)]
        public NamedElementCollection<TypeMappingData> Mappings
        {
            get { return (NamedElementCollection<TypeMappingData>)this[MappingsPropertyName]; }
            set { this[MappingsPropertyName] = value; }
        }
    }
}
