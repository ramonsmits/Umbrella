using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

using ObjectBuilder;

using Nventive.Framework.Extensions;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Nventive.Framework.Configuration;
using Nventive.Framework.Factories;
using Nventive.Framework.Contexts;

namespace Nventive.Framework.ObjectBuilder
{
    public class BuildKeyMappingData : ContextEntryData
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

            IFactoryContext factoryContext = context.GetService<IFactoryContext>();

            //TODO Extract into a IFactoryMappingService
            Mappings.ForEach(item => factoryContext.Policies.Set<IBuildKeyMappingPolicy>(new BuildKeyMappingPolicy(item.ConcreteType), item.InterfaceType));
        }
    }
}
