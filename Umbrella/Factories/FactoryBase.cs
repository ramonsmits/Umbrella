using System;
using nVentive.Umbrella.Contracts;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Factories
{
    public class FactoryBase : IFactory
    {
        #region IFactory Members

        public object Create(IContract contract)
        {
            var type = contract.GetValueOrDefault<TypeContract, Type>();
            var name = contract.GetValueOrDefault<NameContract, string>();

            return Create(type, name, contract);
        }

        #endregion

        protected virtual object Create(Type type, string name, IContract contract)
        {
            throw new NotImplementedException();
        }
    }
}