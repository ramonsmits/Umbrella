using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;

using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace nVentive.Framework.Patterns.Singleton
{
    public class SingletonTypeMappingData : NamedConfigurationElement
    {
        private const string TypePropertyName = "type";
        private const string ConcreteTypePropertyName = "concreteType";

        [ConfigurationProperty(TypePropertyName, IsRequired = true)]
        [TypeConverter(typeof(AssemblyQualifiedTypeNameConverter))]
        public Type Type
        {
            get { return (Type)base[TypePropertyName]; }
            set { base[TypePropertyName] = value; }
        }

        [ConfigurationProperty(ConcreteTypePropertyName, IsRequired = true)]
        [TypeConverter(typeof(AssemblyQualifiedTypeNameConverter))]
        public Type ConcreteType
        {
            get { return (Type)base[ConcreteTypePropertyName]; }
            set { base[ConcreteTypePropertyName] = value; }
        }
    }
}
