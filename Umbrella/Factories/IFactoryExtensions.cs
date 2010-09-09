using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using nVentive.Umbrella.Contexts;
using nVentive.Umbrella.Contracts;

namespace nVentive.Umbrella.Factories
{
    public interface IFactoryExtensions
    {
        FactoryExtensionPoint Factory(IContext context);

        object Wrap(FactoryExtensionPoint context, Type type, object existing);

        object Create(FactoryExtensionPoint context, Type type);
        object Create(FactoryExtensionPoint context, Type type, object[] args);
        object Create(FactoryExtensionPoint context, Type type, object[] args, IContract contract);
        object Create(FactoryExtensionPoint context, Type type, IContract contract);

        T Create<T>(FactoryExtensionPoint context, Type type);
        T Create<T>(FactoryExtensionPoint context, Type type, object[] args);
        T Create<T>(FactoryExtensionPoint context, Type type, object[] args, IContract contract);
        T Create<T>(FactoryExtensionPoint context, Type type, IContract contract);

        T Wrap<T>(FactoryExtensionPoint context, T existing);

        T Create<T>(FactoryExtensionPoint context);
        T Create<T>(FactoryExtensionPoint context, object[] args);
        T Create<T>(FactoryExtensionPoint context, object[] args, IContract contract);
        T Create<T>(FactoryExtensionPoint context, IContract contract);
    }
}
