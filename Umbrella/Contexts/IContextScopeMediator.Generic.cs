using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nVentive.Umbrella.Contexts
{
    public interface IContextScopeMediator<TContext> : IContextScopeMediator
    {
        new TContext Context { get; }
    }
}
