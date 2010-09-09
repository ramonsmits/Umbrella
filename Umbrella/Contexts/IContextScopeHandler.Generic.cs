using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nVentive.Umbrella.Contexts
{
    public interface IContextScopeHandler<TContext>
    {
        TContext Context { get; set; }
    }

}
