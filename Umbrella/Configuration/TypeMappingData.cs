using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;

using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace nVentive.Umbrella.EnterpriseLibrary.Configuration
{
    public class TypeMappingData : NamedConfigurationElement
    {
        private const string InterfaceTypePropertyName = "interfaceType";
        private const string ConcreteTypePropertyName = "concreteType";

        [ConfigurationProperty(InterfaceTypePropertyName)]
        [TypeConverter(typeof(AssemblyQualifiedTypeNameConverter))]
        public Type InterfaceType
        {
            get { return (Type)this[InterfaceTypePropertyName]; }
            set { this[InterfaceTypePropertyName] = value; }
        }

        [ConfigurationProperty(ConcreteTypePropertyName, IsRequired = true)]
        [TypeConverter(typeof(AssemblyQualifiedTypeNameConverter))]
        public Type ConcreteType
        {
            get { return (Type)this[ConcreteTypePropertyName]; }
            set { this[ConcreteTypePropertyName] = value; }
        }
    }
}
