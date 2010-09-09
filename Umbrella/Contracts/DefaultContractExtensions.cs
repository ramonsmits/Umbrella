using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using nVentive.Umbrella.Collections;
using nVentive.Umbrella.Composite;
using nVentive.Umbrella.Extensions;
using nVentive.Umbrella.Sources;

namespace nVentive.Umbrella.Contracts
{
    public class DefaultContractExtensions : IContractExtensions
    {
        #region IContractExtensions Members

        public IContract Add(IContract lhs, IContract rhs)
        {
            if (lhs == null)
            {
                return rhs;
            }

            if (rhs == null)
            {
                return lhs;
            }

            IEnumerable<IContract> lhsItems = CompositeExtensions.SelectMany(lhs);
            IEnumerable<IContract> rhsItems = CompositeExtensions.SelectMany(rhs);

            CompositeContract contract = new CompositeContract(lhsItems.Concat(rhsItems));

            return contract;
        }

        public virtual T Find<T>(IContract contract) 
            where T : IContract
        {
            return CompositeExtensions.SelectMany(contract).OfType<T>().FirstOrDefault();
        }

        public virtual T Get<T>(IContract contract) 
            where T : IContract
        {
            T result = Find<T>(contract);

            return result.Validation().Found();
        }

        public virtual TValue GetValueOrDefault<TContract, TValue>(IContract contract)
            where TContract : ISource<TValue>, IContract
        {
            TContract foundContract = Find<TContract>(contract);

            return foundContract == null ? default(TValue) : foundContract.Value;
        }

        #endregion
    }
}
