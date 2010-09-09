using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nVentive.Umbrella.Contracts;
using nVentive.Umbrella.Extensions;
using nVentive.Umbrella.Reflection;
using nVentive.Umbrella.Containers;

namespace nVentive.Umbrella.Factories
{
    public abstract class FactoryStrategyBase : Container, IFactoryStrategy
    {
        #region IFactoryStrategy Members

        public virtual bool Fulfill(IContract contract)
        {
            Type type;
            string name;
            ExtractContract(contract, out type, out name);

            return CanFullfill(type, name, contract);
        }

        public virtual object Create(IContract contract)
        {
            Type type;
            string name;
            ExtractContract(contract, out type, out name);

            return Create(type, name, contract);
        }

        #endregion

        protected virtual bool CanFullfill(Type type, string name, IContract contract)
        {
            return false;
        }

        protected virtual object Create(Type type, string name, IContract contract)
        {
            IMethodDescriptor create = this.Reflection().FindDescriptor("GenericCreate").Close(type) as IMethodDescriptor;
            
            return create.Invoke(this, name, contract);
        }

        protected virtual T GenericCreate<T>(string name, IContract contract)
        {
            throw new NotImplementedException();
        }

        protected virtual void ExtractContract(IContract contract, out Type type, out string name)
        {
            type = contract.GetValueOrDefault<TypeContract, Type>();
            name = contract.GetValueOrDefault<NameContract, string>();
        }
    }
}
