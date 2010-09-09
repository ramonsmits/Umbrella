using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nVentive.Umbrella.Contracts;

namespace nVentive.Umbrella.Factories
{
    public class MemberInjectionContract : SourceContract<IEnumerable<string>>
    {
        public MemberInjectionContract(params string[] items)
            : this((IEnumerable<string>)items)
        {
        }

        public MemberInjectionContract(IEnumerable<string> items)
            : base(items)
        {
        }
    }
}
