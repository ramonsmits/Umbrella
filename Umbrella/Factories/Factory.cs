using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nVentive.Umbrella.Contracts;
using nVentive.Umbrella.Composite;
using nVentive.Umbrella.Extensions;

namespace nVentive.Umbrella.Factories
{
    public class Factory : Composite<IFactoryStrategy>, IFactory, IFactoryStrategy
    {
        #region IFactory Members

        public object Create(IContract contract)
        {
            IFactoryStrategy strategy = FindStrategy(contract);

            return strategy.Create(contract);
        }

        #endregion

        #region IFactoryStrategy Members

        public bool Fulfill(IContract contract)
        {
            return FindStrategy(contract) != null;
        }

        #endregion

        protected virtual IFactoryStrategy FindStrategy(IContract contract)
        {
            return Items.FirstOrDefault(item => item.Fulfill(contract));
        }
    }
}
