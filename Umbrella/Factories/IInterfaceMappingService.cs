using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nVentive.Umbrella.Contexts;

namespace nVentive.Umbrella.Factories
{
    public interface IInterfaceMappingService
    {
        void Add(IContext context, Type interfaceType, Type concreteType);
        
        Type Find(IContext context, Type interfaceType);
    }
}
