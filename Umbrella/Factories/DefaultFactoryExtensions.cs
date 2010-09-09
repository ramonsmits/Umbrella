using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using nVentive.Umbrella.Contexts;
using nVentive.Umbrella.Contracts;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Factories
{
    public class DefaultFactoryExtensions : IFactoryExtensions
    {
        #region IFactoryExtensions Members

        public virtual FactoryExtensionPoint Factory(IContext context)
        {
        }

        public virtual object Wrap(FactoryExtensionPoint context, Type type, object existing)
        {
        }

        public virtual object Create(FactoryExtensionPoint context, Type type)
        {
        }

        public virtual object Create(FactoryExtensionPoint context, Type type, object[] args)
        {
        }

        public virtual object Create(FactoryExtensionPoint context, Type type, object[] args, IContract contract)
        {
        }

        public virtual object Create(FactoryExtensionPoint context, Type type, IContract contract)
        {
        }

        public virtual T Create<T>(FactoryExtensionPoint context, Type type)
        {
        }

        public virtual T Create<T>(FactoryExtensionPoint context, Type type, object[] args)
        {
        }

        public virtual T Create<T>(FactoryExtensionPoint context, Type type, object[] args, IContract contract)
        {
        }

        public virtual T Create<T>(FactoryExtensionPoint context, Type type, IContract contract)
        {
        }

        public virtual T Wrap<T>(FactoryExtensionPoint context, T existing)
        {
        }

        public virtual T Create<T>(FactoryExtensionPoint context)
        {
        }

        public virtual T Create<T>(FactoryExtensionPoint context, object[] args)
        {
        }

        public virtual T Create<T>(FactoryExtensionPoint context, object[] args, IContract contract)
        {
        }

        public virtual T Create<T>(FactoryExtensionPoint context, IContract contract)
        {
        }
        #endregion
    }
}
