using System.Collections.Generic;

namespace nVentive.Umbrella.Composite
{
    public interface IComposite<T>
    {
        IList<T> Items { get; }
    }
}