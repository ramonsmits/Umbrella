using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nVentive.Umbrella.Provider
{
    public interface IProvider<TKey, TValue> 
    {
        IDictionary<TKey, TValue> Items { get; }
    }
}
