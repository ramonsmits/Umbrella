using System.Collections.Generic;

namespace nVentive.Umbrella.Containers
{
    public interface IContainer
    {
        IDictionary<string, object> Values { get; }
    }
}