using System.Collections.Generic;
using nVentive.Umbrella.Contracts;

namespace nVentive.Umbrella.Factories
{
    public class ArgumentsContract : SourceContract<IEnumerable<object>>
    {
        public ArgumentsContract(IEnumerable<object> args)
            : base(args)
        {
        }
    }
}