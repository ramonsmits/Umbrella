using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nVentive.Umbrella.Contexts
{
    public interface IContextScope : IDisposable
    {
        object Context { get; }
        bool? Completed { get; set; }
    }
}
