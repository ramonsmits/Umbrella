using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;

using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace nVentive.Umbrella.EnterpriseLibrary.Configuration
{
    public class ConfigurationResolverEntryData : NamedConfigurationElement
    {
        public const string TypePropertyName = "type";

        [ConfigurationProperty(TypePropertyName, IsRequired = true)]
        [TypeConverter(typeof(AssemblyQualifiedTypeNameConverter))]
        public Type Type
        {
            get { return (Type)this[TypePropertyName]; }
            set { this[TypePropertyName] = value; }
        }

    }
}
