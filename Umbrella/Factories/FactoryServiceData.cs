using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nVentive.Umbrella.Contexts;
using nVentive.Umbrella.EnterpriseLibrary.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Configuration;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Factories
{
    [ConfigurationElementType(typeof(FactoryServiceData))]
    public class FactoryServiceData : ServiceData
    {
        private const string StrategiesPropertyName = "strategies";

        [ConfigurationProperty(StrategiesPropertyName, IsRequired = true)]
        public NamedElementCollection<TypeMappingData> Strategies
        {
            get { return (NamedElementCollection<TypeMappingData>)this[StrategiesPropertyName]; }
            set { this[StrategiesPropertyName] = value; }
        }

        protected override object CreateService(IContext context)
        {
            Factory factory = (Factory)base.CreateService(context); 

            Strategies.ForEach(item => factory.Items.Add(item.ConcreteType.CreateInstance<IFactoryStrategy>()));

            return factory;
        }
    }
}
