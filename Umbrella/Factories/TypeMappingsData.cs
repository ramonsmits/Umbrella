using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

using ObjectBuilder;

using nVentive.Umbrella.Extensions;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using nVentive.Umbrella.EnterpriseLibrary.Configuration;
using nVentive.Umbrella.Factories;
using nVentive.Umbrella.Contexts;

namespace nVentive.Umbrella.Factories
{
    [ConfigurationElementType(typeof(TypeMappingsData))]
    public class TypeMappingsData : ContextEntryData
    {
        private const string MappingsPropertyName = "mappings";

        [ConfigurationProperty(MappingsPropertyName, IsRequired=true)]
        public NamedElementCollection<TypeMappingData> Mappings
        {
            get { return (NamedElementCollection<TypeMappingData>)this[MappingsPropertyName]; }
            set { this[MappingsPropertyName] = value; }
        }

        public override void Initialize(IContext context)
        {
            base.Initialize(context);

            IInterfaceMappingService mappingService = context.GetService<IInterfaceMappingService>();

            Mappings.ForEach(item => mappingService.Add(context, item.InterfaceType, item.ConcreteType));
        }
    }
}
