using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ObjectBuilder;

namespace Nventive.Framework.Factories
{
    public interface IFactoryContext
    {
        PolicyList Policies { get; }
        IStrategyChain Strategies { get; }
    }
}
