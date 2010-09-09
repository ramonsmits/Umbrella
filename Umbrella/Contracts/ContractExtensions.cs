using System.Collections.Generic;
using System.Linq;
using nVentive.Umbrella.Contracts;
using nVentive.Umbrella.Sources;

namespace nVentive.Umbrella.Extensions
{
    public static class ContractExtensions
    {
        public static IContract Add(this IContract lhs, IContract rhs)
        {
            if (lhs == null)
            {
                return rhs;
            }

            if (rhs == null)
            {
                return lhs;
            }

            var lhsItems = CompositeExtensions.SelectMany(lhs);
            var rhsItems = CompositeExtensions.SelectMany(rhs);

            var contract = new CompositeContract(lhsItems.Concat(rhsItems));

            return contract;
        }

        public static T Find<T>(this IContract contract)
            where T : IContract
        {
            return CompositeExtensions.SelectMany(contract).OfType<T>().FirstOrDefault();
        }

        public static T Get<T>(this IContract contract)
            where T : class, IContract           
        {
            var result = Find<T>(contract);

            return result.Validation().Found();
        }

        public static TValue GetValueOrDefault<TContract, TValue>(this IContract contract)
            where TContract : class, ISource<TValue>, IContract
        {
            var foundContract = Find<TContract>(contract);

            return foundContract == null ? default(TValue) : foundContract.Value;
        }
    }
}