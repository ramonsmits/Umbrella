using System.Collections.Generic;
using nVentive.Umbrella.Composite;

namespace nVentive.Umbrella.Contracts
{
    public class CompositeContract : Composite<IContract>, IContract
    {
        public CompositeContract()
        {
        }

        public CompositeContract(IEnumerable<IContract> items)
            : base(items)
        {
        }
    }
}