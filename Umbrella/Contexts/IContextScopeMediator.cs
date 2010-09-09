using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nVentive.Umbrella.Contexts
{
    public interface IContextScopeMediator
    {
        object Context { get; }

        IDisposable Subscribe(IContextScope scope);

        IEnumerable<IContextScope> Scopes { get; }
    }
}
